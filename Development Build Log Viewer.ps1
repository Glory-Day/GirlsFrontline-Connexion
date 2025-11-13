# Special text unicode
[Char]$LeftHalfCircleUnicode      = 0x00e0b6
[Char]$RightHalfCircleUnicode     = 0x00e0b4
[Char]$RightTriangleUnicode       = 0x00e0b0
[Char]$SolidUnicode               = 0x002588
[Char]$WindowsPlatformIconUnicode = 0x00f17a
[Char]$MessageUnicode             = 0x00f0e0
[Char]$AdministratorUnicode       = 0x00f2bd
[Char]$ClassUnicode               = 0x00f1b2
[Char]$MethodUnicode              = 0x00f121
[Char]$DownPipeLineUnicode        = 0x00256d
[Char]$UpPipeLineUnicode          = 0x002570
[Char]$PipeLineUnicode            = 0x002500
[Char]$NewPipeLineUnicode         = 0x00251c

# Escape Unicode
[Char]$Esc = [Char]27

# Font Formats Unicode
[String]$Reset  = $Esc + "[0m"
[String]$Bold   = $Esc + "[1m"

# Log file path values
[String]$FilePath = Join-Path $HOME "AppData\LocalLow\GloryDay\GirlsFrontline-Connexion\Build.log"

# Colorful Write-Host Functions
function WriteOperatorSystemBlock() {
    Write-Host $DownPipeLineUnicode$PipeLineUnicode$LeftHalfCircleUnicode$SolidUnicode -ForegroundColor White -NoNewline
    Write-Host $WindowsPlatformIconUnicode' ' -ForegroundColor Black -BackgroundColor White -NoNewline
    Write-Host $SolidUnicode -ForegroundColor White -NoNewline
}

function WriteCalledHeaderBlock([String]$Header) {
    Write-Host $RightTriangleUnicode -ForegroundColor White -BackgroundColor DarkBlue -NoNewline
    Write-Host $SolidUnicode -ForegroundColor DarkBlue -NoNewline
    Write-Host $Bold$Header$Reset -ForegroundColor Black -BackgroundColor DarkBlue -NoNewline
    Write-Host $SolidUnicode$RightHalfCircleUnicode -ForegroundColor DarkBlue
}

function WriteMessageHeaderBlock([String]$Header) {
    Write-Host $RightTriangleUnicode -ForegroundColor White -BackgroundColor DarkCyan -NoNewline
    Write-Host $SolidUnicode -ForegroundColor DarkCyan -NoNewline
    Write-Host $MessageUnicode' '$Bold$Header$Reset -ForegroundColor Black -BackgroundColor DarkCyan -NoNewline
    Write-Host $SolidUnicode$RightHalfCircleUnicode -ForegroundColor DarkCyan
}

function WriteErrorHeaderBlock([String]$Header) {
    Write-Host $RightTriangleUnicode -ForegroundColor White -BackgroundColor DarkRed -NoNewline
    Write-Host $SolidUnicode -ForegroundColor DarkRed -NoNewline
    Write-Host $Bold$Header$Reset -ForegroundColor Black -BackgroundColor DarkRed -NoNewline
    Write-Host $SolidUnicode$RightHalfCircleUnicode -ForegroundColor DarkRed
}

function WriteSuccessHeaderBlock([String]$Header) {
    Write-Host $RightTriangleUnicode -ForegroundColor White -BackgroundColor DarkGreen -NoNewline
    Write-Host $SolidUnicode -ForegroundColor DarkGreen -NoNewline
    Write-Host $Bold$Header$Reset -ForegroundColor Black -BackgroundColor DarkGreen -NoNewline
    Write-Host $SolidUnicode$RightHalfCircleUnicode -ForegroundColor DarkGreen
}

function WriteAdministratorHeaderBlock([String]$Header) {
    Write-Host $RightTriangleUnicode -ForegroundColor White -BackgroundColor DarkYellow -NoNewline
    Write-Host $SolidUnicode -ForegroundColor DarkYellow -NoNewline
    Write-Host $AdministratorUnicode' '$Bold$Header$Reset -ForegroundColor Black -BackgroundColor DarkYellow -NoNewline
    Write-Host $SolidUnicode$RightHalfCircleUnicode -ForegroundColor DarkYellow
}

function WriteClassName([String]$ClassName) {
    Write-Host $NewPipeLineUnicode$PipeLineUnicode -ForegroundColor White -NoNewline
    Write-Host ''$ClassUnicode' '$ClassName -ForegroundColor DarkGray
}

function WriteMethodName([String]$MethodName) {
    Write-Host $UpPipeLineUnicode$PipeLineUnicode -ForegroundColor White -NoNewline
    Write-Host ''$MethodUnicode' '$MethodName -ForegroundColor DarkGray
}

function WriteMethodNameAndMessage([String]$MethodName, [String]$Message) {
    Write-Host $NewPipeLineUnicode$PipeLineUnicode -ForegroundColor White -NoNewline
    Write-Host ''$MethodUnicode' '$MethodName -ForegroundColor DarkGray
    Write-Host $UpPipeLineUnicode$PipeLineUnicode -ForegroundColor White -NoNewline
    
    $Message = $Message -replace '<b>', $Bold
    $Message = $Message -replace '</b>', $Reset

    Write-Host ''$Message
}

# Runs a built unity application
.\Build\GirlsFrontline-Connexion.exe -screen-fullscreen 1 -screen-width 1920 -screen-height 1080

# Initialize existing logs
Set-Content $FilePath ""
Clear-Host

# Prints logs in real time
Get-Content $FilePath -Wait -Tail 70 | ForEach-Object {
    $Array = $_.Split("|");

    switch ($Array[0]) {
        'PROGRESS' {
            WriteOperatorSystemBlock
            WriteCalledHeaderBlock $Array[0]
            WriteClassName $Array[1]
            WriteMethodName $Array[2]
            Write-Host ''
        }
        'MESSAGE' {
            WriteOperatorSystemBlock
            WriteMessageHeaderBlock $Array[0]
            WriteClassName $Array[1]
            WriteMethodNameAndMessage $Array[2] $Array[3]
            Write-Host ''
        }
        'ERROR' {
            WriteOperatorSystemBlock
            WriteErrorHeaderBlock $Array[0]
            WriteClassName $Array[1]
            WriteMethodNameAndMessage $Array[2] $Array[3]
            Write-Host ''
        }
        'ADMINISTRATOR' {
            WriteOperatorSystemBlock
            WriteAdministratorHeaderBlock $Array[0]
            WriteClassName $Array[1]
            WriteMethodNameAndMessage $Array[2] $Array[3]
            Write-Host ''
        }
        'SUCCESS' {
            WriteOperatorSystemBlock
            WriteSuccessHeaderBlock $Array[0]
            WriteClassName $Array[1]
            WriteMethodNameAndMessage $Array[2] $Array[3]
            Write-Host ''
        }
    }
}