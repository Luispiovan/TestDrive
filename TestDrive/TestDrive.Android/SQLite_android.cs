using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Sqlite;
using TestDrive.Data;
using TestDrive.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_android))]
namespace TestDrive.Droid
{
    class SQLite_android : ISQLite
    {
        private const string nomeArquivoDB = "Agendamento.db3";

        public SqliteConnection PegarConexao()
        {
            var caminhoDB = Path.Combine( Androir.OS.Environment.ExternalStorageDirectory.Path,
                nomeArquivoDB);
            return new Sqlite.SqliteConnection(caminhoDB);
        }
    }
}
}