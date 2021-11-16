# What is DevTool?

DevTool is a .NET Framework v4.0 WinForms application.
For more information, check out the official project page: https://eaton-works.com/projects/devtool/

# History & Things to know

Shortly after finishing v1.1.1 in the fall of 2012, work started on v2.0. Work continued until mid-2013. Other projects started taking up my time, so DevTool was put on the backburner. There have been no significant developments since mid-2013, and <b>no further development is currently planned</b>.

The source code in this repository is for the latest, unfinished copy of v2.0. Aside from updating a few project files for Visual Studio 2017 and DevExpress v18.1 compatibility, most of the code is as it was left in mid-2013.

It's been a long time and the exact scope of the update has been lost to memory, but there were several new features in the works:
1. New Debug Printing tab to hook the console's debug output. Intended to replace Watson.
2. New Settings tab that would toggle XAM features and allow full XConfig editing. Big progress was made on XConfig, as you can see in XConfig.cs, but it was never finished due to XDRPC bugs (Microsoft's implementation is not perfect!) and the scare of bricking consoles.
3. The module tree and title information were going to be dynamic and update in real-time. This should be mostly working.

Unfortunately, I cannot remember <i>exactly</i> where I left off.

# Compiling & Running

It is recommended that you simply use the code as a reference in a new project of your own. This is an old project and its age is showing.

Make sure XDK v21173 or higher is installed. Also install <a href="https://go.devexpress.com/DevexpressDownload_UniversalTrial.aspx"> DevExpress WinForms Components</a> v18.1.5 or higher. If higher, make sure you run DevTool through the <a href="https://docs.devexpress.com/ProjectConverter/2529/project-converter">DevExpress Components Project Converter</a>.

Before compiling, copy xdevkit.dll (the 32bit version) into DevTool's bin folder manually or you may get a FileNotFoundException on startup.

You should also have a default console set in Xbox 360 Neighborhood or you may get HRESULT 0x82DA0108.

One final note to those who are really serious about compiling this project: You'll need to hack Microsoft.Test.Xbox.Profiles.dll a bit to modify the access modifiers of some members. This was done as a last resort to gain access to important functionality. You'll see what you need to do when you try to compile. Sorry for any inconvenience!

# Support

The <a href="https://github.com/EatonZ/DevTool/issues">GitHub issue tracker</a> is open for your questions. Since DevTool is no longer in development, bug reports may not be investigated.

# Legal

The <a href="https://choosealicense.com/licenses/mit/">MIT License</a> applies to this project.

No XDK installers or individual components/dlls from the XDK will be provided here. Please don't ask.

You should <a href="https://www.devexpress.com/products/net/controls/winforms/">get your own DevExpress WinForms license</a> if you want to build DevTool from source.
