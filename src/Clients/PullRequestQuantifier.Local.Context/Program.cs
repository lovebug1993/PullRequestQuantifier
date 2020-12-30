﻿namespace PullRequestQuantifier.Local.Context
***REMOVED***
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using global::PullRequestQuantifier.Abstractions.Context;
    using global::PullRequestQuantifier.Client;
    using LibGit2Sharp;

    public static class Program
    ***REMOVED***
        public static async Task Main(string[] args)
        ***REMOVED***
            args = CheckArgs(args);

            IContextGenerator contextGenerator = new ContextGenerator();
            var context = await contextGenerator.Create(args[0]);

            // serialize the new context
            var repoRootPath = new DirectoryInfo(Repository.Discover(args[0])).Parent.FullName;
            var filePath = Path.Combine(repoRootPath, ".prquantifier");
            context.SerializeToYaml(filePath);
            Console.WriteLine(
                $"Generate context for Repo located on '***REMOVED***repoRootPath***REMOVED***'" +
                $", context file located at ***REMOVED***Path.Combine(Environment.CurrentDirectory, filePath)***REMOVED***");
***REMOVED***

        private static string[] CheckArgs(string[] args)
        ***REMOVED***
            // if repo path is missing then consider the local repo
            if (args == null || args.Length == 0)
            ***REMOVED***
                return new[] ***REMOVED*** Environment.CurrentDirectory ***REMOVED***;
    ***REMOVED***

            if (!Directory.Exists(args[0]))
            ***REMOVED***
                throw new DirectoryNotFoundException(args[0]);
    ***REMOVED***

            return args;
***REMOVED***
***REMOVED***
***REMOVED***