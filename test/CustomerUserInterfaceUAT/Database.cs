/**
 * Mark Sarasua
 * www.code-logik.com
 * Database.cs
 * 01 MARCH 2024
 * 
 */

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OMS
{
    /// <summary>
    /// Class <c>Database</c> provides C.R.U.D. operations.
    /// </summary>
    internal class Database
    {
        /// <value>
        /// Property <c>_EMBEDDED_MENU_RESOURCE</c> stores the embedded menu resource path.
        /// </value>
        private const string _EMBEDDED_MENU_RESOURCE = "OMS.Database.Menu.json";

        /// <value>
        /// Property <c>_MENU_DIRECTORY</c> stores the name of the directory where the database lives.
        /// </value>
        private const string _MENU_DIRECTORY = "Database";

        /// <value>
        /// Property <c>_MENU_FILE</c> stores the name of the database file.
        /// </value>
        private const string _MENU_FILE = "Menu.json";

        /// <value>
        /// Property <c>_Path</c> stores the path to the database file.
        /// </value>
        private static string _Path = null;

        /// <summary>
        /// Creates a database if no JSON database is present.
        /// </summary>
        public void create()
        {
            create_path();
            if (!json_menu_found())
            {
                create_data_dir();
                create_default_menu_json();
            }
        }

        /// <summary>
        /// Deserializes and returns the JSON database.
        /// </summary>
        /// <returns>
        /// List<MenuItem> deserialized JSON database.
        /// </returns>
        public List<MenuItem> read()
        {
            return JsonConvert.DeserializeObject<List<MenuItem>>(load_menu_json());
        }

        /// <summary>
        /// Reads and returns the JSON database.
        /// </summary>
        /// <returns>
        /// Serialized JSON database string.
        /// </returns>
        private string load_menu_json()
        {
            return File.ReadAllText(_Path);
        }

        /// <summary>
        /// Creates a default JSON database.
        /// </summary>
        private void create_default_menu_json()
        {
            string json;
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(_EMBEDDED_MENU_RESOURCE))
            {
                using (StreamReader stream_reader = new StreamReader(stream))
                {
                    json = stream_reader.ReadToEnd();
                }
            }
            File.WriteAllText(_Path, json);
        }

        /// <summary>
        /// Creates the data directory.
        /// </summary>
        private void create_data_dir()
        {
            if (!Directory.Exists(_MENU_DIRECTORY))
            {
                Directory.CreateDirectory(_MENU_DIRECTORY);
            }
        }

        /// <summary>
        /// Checks if the JSON database exists.
        /// </summary>
        /// <returns>
        /// The bool result.
        /// </returns>
        private bool json_menu_found()
        {
            return File.Exists(_Path);
        }

        /// <summary>
        /// Creates JSON database _Path string.
        /// </summary>
        private void create_path()
        {
            if (_Path == null)
            {
                _Path = Path.Combine(Directory.GetCurrentDirectory(), _MENU_DIRECTORY);
                _Path = Path.Combine(_Path, _MENU_FILE);
            }
        }
    }
}
