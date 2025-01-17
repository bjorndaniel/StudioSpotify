﻿global using Community.VisualStudio.Toolkit;
global using Microsoft.VisualStudio.Shell;
global using System;
global using Task = System.Threading.Tasks.Task;
using Microsoft.VisualStudio;
using System.Runtime.InteropServices;
using System.Threading;

namespace Remotify
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideToolWindow(typeof(RemotifyToolWindow.Pane), Style = VsDockStyle.Tabbed, Window = WindowGuids.SolutionExplorer)]
    [ProvideToolWindowVisibility(typeof(RemotifyToolWindow.Pane), VSConstants.UICONTEXT.SolutionExists_string)]
    [ProvideToolWindowVisibility(typeof(RemotifyToolWindow.Pane), VSConstants.UICONTEXT.NoSolution_string)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.RemotifyString)]
    public sealed class RemotifyPackage : ToolkitPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.RegisterCommandsAsync();

            this.RegisterToolWindows();
            await Command.InitializeAsync(this);
        }
    }
}