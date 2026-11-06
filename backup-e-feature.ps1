# backup-e-feature.ps1
# Roda na RAIZ do repo (a pasta que tem .git, README.md e RunningCube\)
#   powershell -ExecutionPolicy Bypass -File .\backup-e-feature.ps1
#
# O que faz (sem force, sem reset, sem apagar nada):
#   1. Commita o que estiver pendente no branch atual
#   2. Cria branch backup/unity-2018.2 + tag v0.2-unity2018 e faz push
#   3. Cria branch feature/upgrade-2019 a partir dali e faz push
#   4. Te deixa na feature branch

$ErrorActionPreference = "Stop"

$BackupBranch  = "backup/unity-2018.2"
$BackupTag     = "v0.2-unity2018"
$FeatureBranch = "feature/upgrade-2019"

function Run($cmd) {
    Write-Host "> git $cmd" -ForegroundColor Cyan
    Invoke-Expression "git $cmd"
    if ($LASTEXITCODE -ne 0) { throw "Falhou: git $cmd" }
}

# --- Checagens -------------------------------------------------------------
if (-not (Test-Path ".git")) { throw "Rode na raiz do repo (cade a pasta .git?)" }
if (-not (Test-Path "RunningCube\Assets")) { throw "Nao achei RunningCube\Assets - pasta errada?" }

# Unity aberta segura arquivos e fica reescrevendo coisa
if (Get-Process -Name "Unity" -ErrorAction SilentlyContinue) {
    Write-Host "Feche a Unity antes de rodar (ela fica mexendo nos arquivos)." -ForegroundColor Yellow
    exit 1
}

# Garante que lixo local nao vai pro repo
$ignore = Get-Content ".gitignore" -ErrorAction SilentlyContinue
foreach ($line in @(".vs/", "[Ll]ogs/", "[Uu]ser[Ss]ettings/", "*.apk", "*.exe")) {
    if ($ignore -notcontains $line) { Add-Content ".gitignore" $line }
}
# .vs ja tinha sido commitado no passado: tira do indice (o arquivo continua no seu disco)
git rm -r --cached --quiet --ignore-unmatch "RunningCube/.vs" | Out-Null

# GitHub recusa arquivo > 100 MB
$big = Get-ChildItem -Recurse -File -Path "RunningCube\Assets" |
       Where-Object { $_.Length -gt 100MB }
if ($big) {
    Write-Host "Arquivos > 100MB (GitHub vai recusar):" -ForegroundColor Red
    $big | ForEach-Object { Write-Host "  $($_.FullName)" }
    exit 1
}

# Branch/tag ja existem? Nao sobrescreve.
git rev-parse --verify --quiet $BackupBranch  | Out-Null
if ($LASTEXITCODE -eq 0) { throw "Branch $BackupBranch ja existe. Nada foi alterado." }
git rev-parse --verify --quiet "refs/tags/$BackupTag" | Out-Null
if ($LASTEXITCODE -eq 0) { throw "Tag $BackupTag ja existe. Nada foi alterado." }

# --- 1. Commit do estado atual --------------------------------------------
Run "add -A"
git diff --cached --quiet
if ($LASTEXITCODE -ne 0) {
    Run "commit -m `"Versao refatorada rodando na Unity 2018.2.9f1`""
} else {
    Write-Host "Nada pendente pra commitar, segue." -ForegroundColor DarkGray
}

# --- 2. Backup -------------------------------------------------------------
Run "branch $BackupBranch"
Run "tag -a $BackupTag -m `"Backup antes do upgrade de Unity (2018.2.9f1)`""
Run "push -u origin $BackupBranch"
Run "push origin $BackupTag"

# --- 3. Feature branch -----------------------------------------------------
Run "switch -c $FeatureBranch $BackupBranch"
Run "push -u origin $FeatureBranch"

Write-Host ""
Write-Host "Pronto." -ForegroundColor Green
Write-Host "  Backup : $BackupBranch  (tag $BackupTag)"
Write-Host "  Agora em: $FeatureBranch"
Write-Host "Se der ruim no upgrade: git switch $BackupBranch"
