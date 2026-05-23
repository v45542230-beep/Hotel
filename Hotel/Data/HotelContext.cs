using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel.Data
{
    public class HotelContext
    {
        public string ConnectionString { get; set; }
        public HotelContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Clients> GetClients()
        {
            List<Clients> list = new List<Clients>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM clients order by id", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Clients()
                        {
                            Id = reader.GetInt32("id"),
                            Fio = reader.GetString("fio"),
                            Birth = reader.GetDateTime("birth"),
                            Series = reader.GetString("series"),
                            Number = reader.GetString("number"),
                            Date_of_issue = reader.GetDateTime("date_of_issue"),
                            Issued_by_whom = reader.GetString("issued_by_whom"),
                            Card = reader.GetString("card"),
                            Phone = reader.GetString("phone"),
                            Email = reader.GetString("email"),
                        });
                    }
                }
            }
            return list;
        }
        public List<Rooms> GetRooms()
        {
            List<Rooms> list = new List<Rooms>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM rooms order by id", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Rooms()
                        {
                            Id = reader.GetInt32("id"),
                            Type = reader.GetString("type"),
                            Count = reader.GetInt32("count"),
                            Status = reader.GetString("status"),
                            Price = reader.GetInt32("price"),
                            Floor = reader.GetInt32("floor"),
                        });
                    }
                }
            }
            return list;
        }
        public List<Post> GetPost()
        {
            List<Post> list = new List<Post>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM post order by id", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Post()
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Pay = reader.GetInt32("pay"),
                        });
                    }
                }
            }
            return list;
        }
        public List<Staff> GetStaff()
        {
            List<Staff> list = new List<Staff>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM staff order by id", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Staff()
                        {
                            Id = reader.GetInt32("id"),
                            Fio = reader.GetString("fio"),
                            Birth = reader.GetDateTime("birth"),
                            Series = reader.GetString("series"),
                            Number = reader.GetString("number"),
                            Date_of_issue = reader.GetDateTime("date_of_issue"),
                            Issued_by_whom = reader.GetString("issued_by_whom"),
                            Phone = reader.GetString("phone"),
                            Email = reader.GetString("email"),
                            Id_p = reader.GetInt32("id_p"),
                            Date_of_employment = reader.GetDateTime("date_of_employment"),
                        });
                    }
                }
            }
            return list;
        }
        public List<Service> GetService()
        {
            List<Service> list = new List<Service>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM service order by id", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Service()
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Id_st = reader.GetInt32("id_st"),
                            Id_c = reader.GetInt32("id_c"),
                            Date_of_registration = reader.GetDateTime("date_of_registration"),
                        });
                    }
                }
            }
            return list;
        }
        public List<Booking> GetBooking()
        {
            List<Booking> list = new List<Booking>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM booking order by id", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Booking()
                        {
                            Id = reader.GetInt32("id"),
                            Id_c = reader.GetInt32("id_c"),
                            Id_r = reader.GetInt32("id_r"),
                            Begin_date = reader.GetDateTime("begin_date"),
                            End_date = reader.GetDateTime("end_date"),
                            Count_c = reader.GetInt32("count_c"),
                            Final_price = reader.GetInt32("final_price"),
                        });
                    }
                }
            }
            return list;
        }
        public List<Income> GetIncome()
        {
            List<Income> list = new List<Income>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM Годовой_доход", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Income()
                        {
                            Final_price = reader.GetDecimal("sum(final_price)"),
                            Begin_date = reader.GetInt32("year(begin_date)"),
                        });
                    }
                }
            }
            return list;
        }
        public List<Guests> GetGuests()
        {
            List<Guests> list = new List<Guests>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM Текущие_постояльцы", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Guests()
                        {
                            Fio = reader.GetString("fio"),
                            Id_r = reader.GetInt32("id_r"),
                            Begin_date = reader.GetDateTime("begin_date"),
                            End_date = reader.GetDateTime("end_date"),
                        });
                    }
                }
            }
            return list;
        }
        public List<Personal> GetPersonal()
        {
            List<Personal> list = new List<Personal>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM Персонал", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Personal()
                        {
                            Fio = reader.GetString("fio"),
                            Name = reader.GetString("name"),
                            Date_of_employment = reader.GetDateTime("date_of_employment"),
                            Pay = reader.GetInt32("pay"),
                        });
                    }
                }
            }
            return list;
        }
        public Clients GetOneClient(int id)
        {
            Clients list = new Clients { };
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM clients where id={id}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list = new Clients
                        {
                            Id = reader.GetInt32("id"),
                            Fio = reader.GetString("fio"),
                            Birth = reader.GetDateTime("birth"),
                            Series = reader.GetString("series"),
                            Number = reader.GetString("number"),
                            Date_of_issue = reader.GetDateTime("date_of_issue"),
                            Issued_by_whom = reader.GetString("issued_by_whom"),
                            Card = reader.GetString("card"),
                            Phone = reader.GetString("phone"),
                            Email = reader.GetString("email"),
                        };
                    }
                }
            }
            return list;
        }
        public Clients GetOneClientByFioAndPhone(string fio, string phone)
        {
            Clients list = new Clients { };
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM clients where fio='{fio}' and phone='{phone}'", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list = new Clients
                        {
                            Id = reader.GetInt32("id"),
                            Fio = reader.GetString("fio"),
                            Birth = reader.GetDateTime("birth"),
                            Series = reader.GetString("series"),
                            Number = reader.GetString("number"),
                            Date_of_issue = reader.GetDateTime("date_of_issue"),
                            Issued_by_whom = reader.GetString("issued_by_whom"),
                            Card = reader.GetString("card"),
                            Phone = reader.GetString("phone"),
                            Email = reader.GetString("email"),
                        };
                    }
                }
            }
            return list;
        }
        public Rooms GetOneRoom(int id)
        {
            Rooms list = new Rooms { };
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM rooms where id={id}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list = new Rooms
                        {
                            Id = reader.GetInt32("id"),
                            Type = reader.GetString("type"),
                            Count = reader.GetInt32("count"),
                            Status = reader.GetString("status"),
                            Price = reader.GetInt32("price"),
                            Floor = reader.GetInt32("floor"),
                        };
                    }
                }
            }
            return list;
        }
        public Post GetOnePost(int id)
        {
            Post list = new Post { };
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM post where id={id}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list = new Post
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Pay = reader.GetInt32("pay"),
                        };
                    }
                }
            }
            return list;
        }
        public Staff GetOneStaff(int id)
        {
            Staff list = new Staff { };
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM staff where id={id}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list = new Staff
                        {
                            Id = reader.GetInt32("id"),
                            Fio = reader.GetString("fio"),
                            Birth = reader.GetDateTime("birth"),
                            Series = reader.GetString("series"),
                            Number = reader.GetString("number"),
                            Date_of_issue = reader.GetDateTime("date_of_issue"),
                            Issued_by_whom = reader.GetString("issued_by_whom"),
                            Phone = reader.GetString("phone"),
                            Email = reader.GetString("email"),
                            Id_p = reader.GetInt32("id_p"),
                            Date_of_employment = reader.GetDateTime("date_of_employment"),
                        };
                    }
                }
            }
            return list;
        }
        public Service GetOneService(int id)
        {
            Service list = new Service { };
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM service where id={id}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list = new Service
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Id_st = reader.GetInt32("id_st"),
                            Id_c = reader.GetInt32("id_c"),
                            Date_of_registration = reader.GetDateTime("date_of_registration"),
                        };
                    }
                }
            }
            return list;
        }
        public Booking GetOneBooking(int id)
        {
            Booking list = new Booking { };
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM booking where id={id}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list = new Booking
                        {
                            Id = reader.GetInt32("id"),
                            Id_c = reader.GetInt32("id_c"),
                            Id_r = reader.GetInt32("id_r"),
                            Begin_date = reader.GetDateTime("begin_date"),
                            End_date = reader.GetDateTime("end_date"),
                            Count_c = reader.GetInt32("count_c"),
                            Final_price = reader.GetInt32("final_price"),
                        };
                    }
                }
            }
            return list;
        }
        public void InsertClients(Clients client)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "insert into clients(fio,birth,series,number,date_of_issue,issued_by_whom,card,phone,email) values(@fio,@birth,@series,@number,@date_of_issue,@issued_by_whom,@card,@phone,@email)";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@fio", client.Fio);
                    cmd.Parameters.AddWithValue("@birth", client.Birth);
                    cmd.Parameters.AddWithValue("@series", client.Series);
                    cmd.Parameters.AddWithValue("@number", client.Number);
                    cmd.Parameters.AddWithValue("@date_of_issue", client.Date_of_issue);
                    cmd.Parameters.AddWithValue("@issued_by_whom", client.Issued_by_whom);
                    cmd.Parameters.AddWithValue("@card", client.Card);
                    cmd.Parameters.AddWithValue("@phone", client.Phone);
                    cmd.Parameters.AddWithValue("@email", client.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void InsertRooms(Rooms room)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "insert into rooms(type,count,status,price,floor) values(@type,@count,@status,@price,@floor)";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@type", room.Type);
                    cmd.Parameters.AddWithValue("@count", room.Count);
                    cmd.Parameters.AddWithValue("@status", room.Status);
                    cmd.Parameters.AddWithValue("@price", room.Price);
                    cmd.Parameters.AddWithValue("@floor", room.Floor);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void InsertPost(Post post)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "insert into post(name,pay) values(@name,@pay)";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@name", post.Name);
                    cmd.Parameters.AddWithValue("@pay", post.Pay);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void InsertStaff(Staff staff)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "insert into staff(fio,birth,series,number,date_of_issue,issued_by_whom,phone,email,id_p,date_of_employment) values(@fio,@birth,@series,@number,@date_of_issue,@issued_by_whom,@phone,@email,@id_p,@date_of_employment)";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@fio", staff.Fio);
                    cmd.Parameters.AddWithValue("@birth", staff.Birth);
                    cmd.Parameters.AddWithValue("@series", staff.Series);
                    cmd.Parameters.AddWithValue("@number", staff.Number);
                    cmd.Parameters.AddWithValue("@date_of_issue", staff.Date_of_issue);
                    cmd.Parameters.AddWithValue("@issued_by_whom", staff.Issued_by_whom);
                    cmd.Parameters.AddWithValue("@phone", staff.Phone);
                    cmd.Parameters.AddWithValue("@email", staff.Email);
                    cmd.Parameters.AddWithValue("@id_p", staff.Id_p);
                    cmd.Parameters.AddWithValue("@date_of_employment", staff.Date_of_employment);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void InsertService(Service service)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "insert into service(name,id_st,id_c,date_of_registration) values(@name,@id_st,@id_c,@date_of_registration)";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@name", service.Name);
                    cmd.Parameters.AddWithValue("@id_st", service.Id_st);
                    cmd.Parameters.AddWithValue("@id_c", service.Id_c);
                    cmd.Parameters.AddWithValue("@date_of_registration", service.Date_of_registration);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void InsertBooking(Booking booking)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "insert into booking(id_c,id_r,begin_date,end_date,count_c,final_price) values(@id_c,@id_r,@begin_date,@end_date,@count_c,@final_price)";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@id_c", booking.Id_c);
                    cmd.Parameters.AddWithValue("@id_r", booking.Id_r);
                    cmd.Parameters.AddWithValue("@begin_date", booking.Begin_date);
                    cmd.Parameters.AddWithValue("@end_date", booking.End_date);
                    cmd.Parameters.AddWithValue("@count_c", booking.Count_c);
                    cmd.Parameters.AddWithValue("@final_price", booking.Final_price);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateClient(Clients client)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "update clients set fio=@fio,birth=@birth,series=@series,number=@number,date_of_issue=@date_of_issue,issued_by_whom=@issued_by_whom,card=@card,phone=@phone,email=@email where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@id", client.Id);
                    cmd.Parameters.AddWithValue("@fio", client.Fio);
                    cmd.Parameters.AddWithValue("@birth", client.Birth);
                    cmd.Parameters.AddWithValue("@series", client.Series);
                    cmd.Parameters.AddWithValue("@number", client.Number);
                    cmd.Parameters.AddWithValue("@date_of_issue", client.Date_of_issue);
                    cmd.Parameters.AddWithValue("@issued_by_whom", client.Issued_by_whom);
                    cmd.Parameters.AddWithValue("@card", client.Card);
                    cmd.Parameters.AddWithValue("@phone", client.Phone);
                    cmd.Parameters.AddWithValue("@email", client.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateRoom(Rooms room)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "update rooms set type=@type,count=@count,status=@status,price=@price,floor=@floor where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@id", room.Id);
                    cmd.Parameters.AddWithValue("@type", room.Type);
                    cmd.Parameters.AddWithValue("@count", room.Count);
                    cmd.Parameters.AddWithValue("@status", room.Status);
                    cmd.Parameters.AddWithValue("@price", room.Price);
                    cmd.Parameters.AddWithValue("@floor", room.Floor);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdatePost(Post post)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "update post set name=@name,pay=@pay where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@id", post.Id);
                    cmd.Parameters.AddWithValue("@name", post.Name);
                    cmd.Parameters.AddWithValue("@pay", post.Pay);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateStaff(Staff staff)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "update staff set fio=@fio,birth=@birth,series=@series,number=@number,date_of_issue=@date_of_issue,issued_by_whom=@issued_by_whom,phone=@phone,email=@email,id_p=@id_p,date_of_employment=@date_of_employment where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@fio", staff.Fio);
                    cmd.Parameters.AddWithValue("@birth", staff.Birth);
                    cmd.Parameters.AddWithValue("@series", staff.Series);
                    cmd.Parameters.AddWithValue("@number", staff.Number);
                    cmd.Parameters.AddWithValue("@date_of_issue", staff.Date_of_issue);
                    cmd.Parameters.AddWithValue("@issued_by_whom", staff.Issued_by_whom);
                    cmd.Parameters.AddWithValue("@phone", staff.Phone);
                    cmd.Parameters.AddWithValue("@email", staff.Email);
                    cmd.Parameters.AddWithValue("@id_p", staff.Id_p);
                    cmd.Parameters.AddWithValue("@date_of_employment", staff.Date_of_employment);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateService(Service service)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "update service set name=@name,id_st=@id_st,id_c=@id_c,date_of_registration=@date_of_registration where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@name", service.Name);
                    cmd.Parameters.AddWithValue("@id", service.Id);
                    cmd.Parameters.AddWithValue("@id_st", service.Id_st);
                    cmd.Parameters.AddWithValue("@id_c", service.Id_c);
                    cmd.Parameters.AddWithValue("@date_of_registration", service.Date_of_registration);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateBooking(Booking booking)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "update booking set id_c=@id_c,id_r=@id_r,begin_date=@begin_date,end_date=@end_date,count_c=@count_c,final_price=@final_price where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@id", booking.Id);
                    cmd.Parameters.AddWithValue("@id_c", booking.Id_c);
                    cmd.Parameters.AddWithValue("@id_r", booking.Id_r);
                    cmd.Parameters.AddWithValue("@begin_date", booking.Begin_date);
                    cmd.Parameters.AddWithValue("@end_date", booking.End_date);
                    cmd.Parameters.AddWithValue("@count_c", booking.Count_c);
                    cmd.Parameters.AddWithValue("@final_price", booking.Final_price);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteClient(Clients client)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "delete from clients where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@id", client.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteRoom(Rooms room)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "delete from rooms where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@id", room.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeletePost(Post post)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "delete from post where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@id", post.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteStaff(Staff staff)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "delete from staff where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@id", staff.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteService(Service service)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "delete from service where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@id", service.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteBooking(Booking booking)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                String cmd_text = "delete from booking where id=@id";
                using (MySqlCommand cmd = new MySqlCommand(cmd_text, conn))
                {
                    cmd.Parameters.AddWithValue("@id", booking.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
