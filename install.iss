; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "PaLoSi"
#define MyAppVersion "1.0.2"
#define MyAppExeName "PaLoSi.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{D41FCBC1-78D4-4F08-88C6-AFE42AED80E2}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin1\Debug\��� ������� ������ ������� PaLoSi.rtf
InfoBeforeFile=C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin1\Debug\��������.rtf
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\PaLoSi.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\HtmlAgilityPack.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\Jint.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\kpr.bin"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\LicensTest.mht"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\opisanie.mht"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\PaLoSi.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\PaLoSi.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\PaLoSi.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\spu.bin"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\System.Data.SQLite.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\tmplicens.mht"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����� ��������\Documents\SharpDevelop Projects\PaLoSi\PaLoSi\bin\Debug\��������.mht"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

