// -----------------------------------------------------------------------
// <copyright file="LabelCommand.cs" company="GitTools Contributors">
// Copyright (c) 2015 - Present - GitTools Contributors
// </copyright>
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using GitReleaseManager.Core.Options;
using Serilog;

namespace GitReleaseManager.Core.Commands
{
    public class LabelCommand : ICommand<LabelSubOptions>
    {
        private readonly IVcsService _vcsService;
        private readonly ILogger _logger;

        public LabelCommand(IVcsService vcsService, ILogger logger)
        {
            _vcsService = vcsService;
            _logger = logger;
        }

        public async Task<int> Execute(LabelSubOptions options)
        {
            _logger.Information("Creating standard labels");
            await _vcsService.CreateLabelsAsync(options.RepositoryOwner, options.RepositoryName).ConfigureAwait(false);

            return 0;
        }
    }
}