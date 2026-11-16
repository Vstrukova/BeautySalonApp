using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; 
using System.Windows.Forms;

namespace BeautySalonApp 
{
    public class SqlDB
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=beauty_salon;Integrated Security=True;";

        private string TABLENAME = "Masters";
        private const string TABLENAME_USERS = "Users";

        public List<int> rows = new List<int>();
        public string firstName, lastName, login, password;
        public string status = "User";

        public void showTable(DataGridView grid, string filterString = "")
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection connection = new SqlConnection(connectionString);

                string querySelectAll = "SELECT * FROM " + TABLENAME;
                SqlDataAdapter adapter = new SqlDataAdapter(querySelectAll, connection);
                adapter.Fill(ds);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = ds.Tables[0];

              
                bindingSource.Filter = filterString;

                grid.DataSource = bindingSource;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        public void saveTable(DataGridView grid)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                int columnCount = grid.ColumnCount;

                grid.Columns["id_master"].ReadOnly = true;

                for (int i = 0; i < rows.Count; i++)
                {
                    var row = rows[i];
                    string idInSqlDB = grid.Rows[row].Cells[0].Value.ToString();

                    for (int j = 1; j < columnCount; j++)
                    {
                        string colName = grid.Columns[j].Name.ToString();
                        string cellValue = grid.Rows[row].Cells[j].Value.ToString();

                        cmd.CommandText = $"UPDATE {TABLENAME} SET {colName} = @value WHERE id_master = @id";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@value", cellValue);
                        cmd.Parameters.AddWithValue("@id", idInSqlDB);

                        cmd.ExecuteNonQuery();
                    }
                }
                rows.Clear();
                connection.Close();
                MessageBox.Show("Данные сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        public void searchInTable(DataGridView grid, string searchValue)
        {
            string filterString = $"[surname] LIKE '%{searchValue}%' OR [specialization] LIKE '%{searchValue}%'";
            showTable(grid, filterString);
        }

        public void searchByStatus(DataGridView grid, string status)
        {
            string filterString = $"[worker_status] = '{status}'";
            showTable(grid, filterString);
        }
        public bool IsLoginUnique(string loginToCheck)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT id_user FROM {TABLENAME_USERS} WHERE login = @login";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@login", loginToCheck);
                SqlDataReader rdr = cmd.ExecuteReader();
                bool exists = rdr.Read();
                rdr.Close();
                return !exists;
            }
        }
        public bool CreateUser()
        {
            try
            {
                if (!IsLoginUnique(login))
                {
                    MessageBox.Show("Такой логин уже занят. Введите другой.");
                    return false;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = $"INSERT INTO {TABLENAME_USERS} " +
                                 $"(first_name, last_name, login, password, status) VALUES " +
                                 $"(@fn, @ln, @lg, @pw, @st)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@fn", firstName);
                    cmd.Parameters.AddWithValue("@ln", lastName);
                    cmd.Parameters.AddWithValue("@lg", login);
                    cmd.Parameters.AddWithValue("@pw", password);
                    cmd.Parameters.AddWithValue("@st", status);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("User created succesfully");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + ": " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool CheckUser(string enteredLogin, string enteredPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT id_user, status FROM {TABLENAME_USERS} " +
                             $"WHERE login = @login AND password = @password";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@login", enteredLogin);
                cmd.Parameters.AddWithValue("@password", enteredPassword);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    string st = rdr["status"].ToString();
                    rdr.Close();

                    if (st == "Blocked" || st == "Fired")
                    {
                        MessageBox.Show("Доступ запрещён: учётная запись заблокирована или уволена.");
                        return false;
                    }

                    MessageBox.Show("User exist. Successfuly login");
                    return true;
                }

                rdr.Close();
                MessageBox.Show($"User: {enteredLogin} not exist or password is wrong");
                return false;
            }
        }
        public void ChangeStatus(string newStatus, int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"UPDATE {TABLENAME_USERS} SET status = @status WHERE id_user = @id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();
            }
        }
        public void ShowUsers(DataGridView grid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT id_user, first_name, last_name, login, status FROM {TABLENAME_USERS}";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                grid.DataSource = table;
            }
        }
    }
}