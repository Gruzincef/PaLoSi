/*
 * Created by SharpDevelop.
 * User: Админ
 * Date: 04.01.2020
 * Time: 23:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
namespace PaLoSi
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class FormConfiguration : Form
	{
	
	
public FormConfiguration(MainForm f){ InitializeComponent();frm=f;}
private string  nameThreading="";	
MainForm frm;
private ListSites.Project prjct=new ListSites.Project();
private ListSites lstst=new ListSites();
private Work wrk=new Work();
public FormConfiguration(string namethreading, MainForm f){
	frm=f;
	InitializeComponent();
	PathLoadIMGBox1textBox1.Text=System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
	tabControl1.TabPages.Remove(tabPage5);
	if(namethreading.Length>0){
		nameThreading=namethreading;
		ListSites.Project prjct=ListSites.listSites[nameThreading];
		LoadConfigProject(prjct);
	}
}

public FormConfiguration(ListSites.Project prjt, MainForm f){
	frm=f;
	InitializeComponent();
	tabControl1.TabPages.Remove(tabPage5);
	nameThreading="";
	LoadConfigProject(prjt);
}


public void LoadConfigProject(ListSites.Project prjt){
	prjct.blocInfo=new  List<ListSites.BlocInfo>();
	prjct.blocInfo.AddRange(prjt.blocInfo);
if(prjt.PathLoadIMG.Length==0)prjt.PathLoadIMG=System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
if(prjt.pathAutoExport.Length==0)prjt.pathAutoExport=System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
		
textBoxNameProject.Text=prjt.nameProject;
textBoxAddresSite.Text=prjt.addresSite;
textBoxErrorLoad.Text=prjt.errorLoad;
checkBoxLoadFile.Checked=prjt.loadIntegratedImg;
StopOldLoadcheckBox1.Checked=prjt.StopOldLoad;
immersionDepthnumericUpDown1.Value=prjt.immersionDepth;
pathAutoExporttextBox1.Text=prjt.pathAutoExport;
AllLoadcheckBox1.Checked=prjt.AllLoad;
DirSaveImgcomboBox1.Text=prjt.DirSaveImg;
if(prjt.PathLoadIMG.Length>0) PathLoadIMGBox1textBox1.Text=prjt.PathLoadIMG;
else PathLoadIMGBox1textBox1.Text=System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile); 
ViewHreftextBox1.Text=prjt.ViewHref;
MaxFileSizenumericUpDown2.Value=prjt.MaxFileSize;
MinFileSizenumericUpDown1.Value=prjt.MinFileSize;
theFrequencyOfnumericUpDown1.Value=prjt.theFrequencyOf;
for(int i=0;i<prjt.blocInfo.Count;i++)
	listBoxInfoxBox.Items.Add(prjt.blocInfo[i].nameInfoBlock);
for(int i=0;i<prjt.proxiPort.Count;i++)
	listBoxProxi.Items.Add(prjt.proxiPort[i].proxi+":"+prjt.proxiPort[i].port);
for(int i=0;i<prjt.listLoadFile.Count;i++)
	checkedListLoadFile.SetItemChecked(checkedListLoadFile.FindString(prjt.listLoadFile[i].ToString()),true);
}
void CheckedListBox1SelectedIndexChanged(object sender, EventArgs e){
	
	
}
void ButtonCloseClick(object sender, EventArgs e){
frm.LoadConfig();
this.Close();
}
void LoadInCheckList(ListBox listBox,List<string> s){
	listBox.Items.Clear();
	for(int i=0;i<s.Count;i++)
		listBox.Items.Add(s[i]);	
}
void ButtonAddProxiClick(object sender, EventArgs e){
	prjct.proxiPort.Add(lstst.ConvertProxiPort(textBoxProxi.Text));
	LoadInCheckList(listBoxProxi,lstst.GetlistProxiPort(prjct.proxiPort));
}
void ButtonDeleteProxiClick(object sender, EventArgs e)	{
	prjct.proxiPort.RemoveAt(listBoxProxi.SelectedIndex);
	LoadInCheckList(listBoxProxi,lstst.GetlistProxiPort(prjct.proxiPort));
}
void ButtonAddInfoBoxClick(object sender, EventArgs e){
	ListSites.BlocInfo blocinfo=new ListSites.BlocInfo();
	blocinfo.nameInfoBlock=textBoxNameInfoBlock.Text;
	blocinfo.clearTeg=checkBoxClearTeg.Checked;
	blocinfo.locationNameClass=(LOCATIONAMECLASS_TYPE)Enum.Parse(typeof(LOCATIONAMECLASS_TYPE),comboBoxLocationNameClass.Text);
	blocinfo.nameClass=textBoxNameClass.Text;
	blocinfo.boxType=(BOXTYPE_TYPE)Enum.Parse(typeof(BOXTYPE_TYPE),comboBoxType.Text);
	blocinfo.boxTeg=(BOXTEG_TYPE)Enum.Parse(typeof(BOXTEG_TYPE),comboBoxTeg.Text);
	if(prjct.blocInfo==null)
	prjct.blocInfo=new List<ListSites.BlocInfo>();
	prjct.blocInfo.Add(blocinfo);
	LoadInCheckList(listBoxInfoxBox,lstst.GetlistBlocInfo(prjct.blocInfo));
}
void ButtonDeleteInfoBoxClick(object sender, EventArgs e){
	prjct.blocInfo.RemoveAt(listBoxInfoxBox.SelectedIndex);
	LoadInCheckList(listBoxInfoxBox,lstst.GetlistBlocInfo(prjct.blocInfo));
}
void ListBoxInfoxBoxSelectedIndexChanged(object sender, EventArgs e){
	int i=listBoxInfoxBox.SelectedIndex;
	if(i>-1){
		textBoxNameInfoBlock.Text=prjct.blocInfo[i].nameInfoBlock;
		checkBoxClearTeg.Checked=prjct.blocInfo[i].clearTeg;
		comboBoxLocationNameClass.Text=prjct.blocInfo[i].locationNameClass.ToString();
		textBoxNameClass.Text=prjct.blocInfo[i].nameClass;
		comboBoxType.Text=prjct.blocInfo[i].boxType.ToString();
		comboBoxTeg.Text=prjct.blocInfo[i].boxTeg.ToString();
	}
}
void ButtonUpdateInfoBoxClick(object sender, EventArgs e){
	prjct.blocInfo.RemoveAt(listBoxInfoxBox.SelectedIndex);
	ListSites.BlocInfo blocinfo=new ListSites.BlocInfo();
	blocinfo.nameInfoBlock=textBoxNameInfoBlock.Text;
	blocinfo.clearTeg=checkBoxClearTeg.Checked;
	blocinfo.locationNameClass=(LOCATIONAMECLASS_TYPE)Enum.Parse(typeof(LOCATIONAMECLASS_TYPE),comboBoxLocationNameClass.Text);
	blocinfo.nameClass=textBoxNameClass.Text;
	blocinfo.boxType=(BOXTYPE_TYPE)Enum.Parse(typeof(BOXTYPE_TYPE),comboBoxType.Text);
	blocinfo.boxTeg=(BOXTEG_TYPE)Enum.Parse(typeof(BOXTEG_TYPE),comboBoxTeg.Text);
	prjct.blocInfo.Add(blocinfo);
	LoadInCheckList(listBoxInfoxBox,lstst.GetlistBlocInfo(prjct.blocInfo));

}
void ButtonSaveProjectClick(object sender, EventArgs e)	{
	if(textBoxNameProject.Text.Length>0){
	if((nameThreading.Length>0)||(!ListSites.listSites.ContainsKey(Work.TransliterationType(textBoxNameProject.Text)))){
		List<string> listLoadFile=new List<string>();
		if(nameThreading.Length>0) ListSites.listSites.Remove(nameThreading);
		for(int i=0;i<checkedListLoadFile.CheckedItems.Count;i++)
			listLoadFile.Add(checkedListLoadFile.CheckedItems[i].ToString());
		prjct.DirSaveImg=DirSaveImgcomboBox1.Text;
		prjct.PathLoadIMG=PathLoadIMGBox1textBox1.Text;
		prjct.StopOldLoad=StopOldLoadcheckBox1.Checked;
		prjct.addresSite=textBoxAddresSite.Text;
		prjct.nameProject=textBoxNameProject.Text;
		prjct.ViewHref=ViewHreftextBox1.Text;
		prjct.theFrequencyOf=(int)theFrequencyOfnumericUpDown1.Value;
		prjct.immersionDepth=(int)immersionDepthnumericUpDown1.Value;
		prjct.pathAutoExport=pathAutoExporttextBox1.Text;
		prjct.errorLoad=textBoxErrorLoad.Text;
		prjct.loadIntegratedImg=checkBoxLoadFile.Checked;
		prjct.listLoadFile=new List<LISTLOADFILE_TYPE>();
		prjct.MaxFileSize=MaxFileSizenumericUpDown2.Value;
		prjct.MinFileSize=MinFileSizenumericUpDown1.Value;
	//	prjct.blocInfo.AddRange()
		for(int i=0;i<listLoadFile.Count;i++)
			prjct.listLoadFile.Add((LISTLOADFILE_TYPE)Enum.Parse(typeof(LISTLOADFILE_TYPE),listLoadFile[i]));
		prjct.AllLoad=AllLoadcheckBox1.Checked;
		prjct.nameThreading=Work.TransliterationType(textBoxNameProject.Text);
		lstst.AddListProject(prjct);
		MainForm.frm.checkedListProject=-1;
		MainForm.frm.LoadConfig();
		this.Close();
	}else{
	DialogResult dialogresult=MessageBox.Show("Change the project name!", "Change the project name!", MessageBoxButtons.OK);
	}
	}
}
void ShapeViewHreftextbutton2Click(object sender, EventArgs e){
	ConfigurationHrefForm1 frm=new ConfigurationHrefForm1(ViewHreftextBox1);
	frm.Show(ViewHreftextBox1);
	}
void Selectbutton1Click(object sender, EventArgs e){
	if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
		pathAutoExporttextBox1.Text= folderBrowserDialog1.SelectedPath;
}
void TabControl1SelectedIndexChanged(object sender, EventArgs e){
	NameBlockImportcomboBox1.Items.Clear();
	NameBlockImportcomboBox1.Items.Add("Href");
	if(ListSites.listSites.ContainsKey(nameThreading)){
		prjct=ListSites.listSites[nameThreading];
		if(prjct.blocInfo!=null)
		for(int i=0; i<prjct.blocInfo.Count;i++)
			NameBlockImportcomboBox1.Items.Add(prjct.blocInfo[i].nameInfoBlock);
		ListXMLImportcheckedListBox1.Items.Clear();
		if(prjct.nameBlocFileExportXML!=null)
		for(int i=0;i<prjct.nameBlocFileExportXML.Count;i++)
			ListXMLImportcheckedListBox1.Items.Add(prjct.nameBlocFileExportXML[i].ToString());
	}
}

void AddBlocImportbutton1Click(object sender, EventArgs e){
	prjct.nameBlocFileExportXML.Add(NameBlockImportcomboBox1.Text);
	ListXMLImportcheckedListBox1.Items.Add(NameBlockImportcomboBox1.Text);
}
void DeleteBlockImportbutton1Click(object sender, EventArgs e){
	for(int i=ListXMLImportcheckedListBox1.Items.Count;i>=0;i--){
		ListXMLImportcheckedListBox1.Items.RemoveAt(i);
		prjct.nameBlocFileExportXML.RemoveAt(i);
	
	}
}
void Button1Click(object sender, EventArgs e){
	if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
		PathLoadIMGBox1textBox1.Text= folderBrowserDialog1.SelectedPath;

}
		void TabPage4Click(object sender, EventArgs e)
		{

		}
		void FormConfigurationLoad(object sender, EventArgs e)
		{
	
		}


		
	}
}
