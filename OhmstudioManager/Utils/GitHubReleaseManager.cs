﻿/* 
 * This file is part of the MyOhmSessions distribution (https://github.com/GroovemanAndCo/MyOhmStudio).
 * Copyright (c) 2020 Fabien (https://github.com/fab672000)
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;

namespace OhmstudioManager.Utils
{
    public static class GitHubReleasesManager
    {
        /// <summary>
        /// Get the latest tag update from the website or null if not found
        /// </summary>
        /// <param name="downloadUrl">on return this parameter is set to the downloadUrl if any</param>
        /// <returns></returns>
        public static string GetUpdates(out string downloadUrl)
        {
            downloadUrl = null;
            Cursor.Current = Cursors.WaitCursor;

            var release = CheckForUpdatedReleases("db7b37e702b712caf82f9afaa85e27733a7d6b9b"); // public read only key
            if (release?.Assets.Count > 0)
            {

                var exe = release.Assets.Where(x => x.Name.EndsWith(".exe")).FirstOrDefault();
                if (exe==null) return null;
                downloadUrl = exe?.BrowserDownloadUrl;
                return release.TagName;
            }

            Cursor.Current = Cursors.Default;

            return null;

        }

        public static Release CheckForUpdatedReleases(string api_key)
        {
            var client = new GitHubClient(new ProductHeaderValue("MyOhmSessions", "v1.3.2"));
            client.Credentials = new Credentials(api_key);
            var result = Task.Run(() => client.Repository.Release.GetAll("GroovemanAndCo", "MyOhmStudio"));
            if (!result.Wait(5000)) return null;
            var releases = result.Result;
            if (releases?.Count==0 ) return null;
            var release = releases.OrderByDescending(x => x.TagName).First();
            return release;
        }
    }
}
