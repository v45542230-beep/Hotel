using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<Users> signInManager;
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<Users> signInManager, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            return View(context.GetRooms());
        }

        [HttpGet]
        public IActionResult CheckClient(CheckClient client, int id)
        {
            client.Id_r = id;
            return View(client);
        }

        [HttpPost]
        public IActionResult CheckClient(Booking booking, CheckClient checkClient)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            Clients client = context.GetOneClientByFioAndPhone(checkClient.Fio, checkClient.Phone);
            if (ModelState.IsValid)
            {
                if (client.Id > 0)
                {
                    booking.Id_r = checkClient.Id_r;
                    booking.Id_c = client.Id;
                    return View("InsertBooking", booking);
                }
                else
                {
                    return View("InsertClient");
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult CheckBooking()
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            return View(context.GetBooking());
        }

        [HttpPost]
        public IActionResult CheckBooking(string field, string column)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            IEnumerable<Booking> booking = context.GetBooking();
            if (field == "id_r" && column != null)
            {
                booking = context.GetBooking().Where(t => t.Id_r.ToString().Contains(column));
            }
            else if (field == "begin_date" && column != null)
            {
                booking = context.GetBooking().Where(t => t.Begin_date.ToString().Contains(column));
            }
            else if (field == "end_date" && column != null)
            {
                booking = context.GetBooking().Where(t => t.End_date.ToString().Contains(column));
            }
            return PartialView("_CheckBooking", booking);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Admin()
        {
            var users = await userManager.Users.ToListAsync();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Admin(string field, string column)
        {
            IEnumerable<Users> user = await userManager.Users.ToListAsync();
            if (field == "name" && column != null)
            {
                user = await userManager.Users.Where(t => t.Name.Contains(column)).ToListAsync();
            }
            else if (field == "email" && column != null)
            {
                user = await userManager.Users.Where(t => t.Email.Contains(column)).ToListAsync();
            }
            return PartialView("_Admin", user);
        }

        [Authorize]
        public IActionResult Clients()
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            return View(context.GetClients());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Clients(string field, string column)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            IEnumerable<Clients> clients = context.GetClients();
            if (field == "fio" && column != null)
            {
                clients = context.GetClients().Where(t => t.Fio.Contains(column));
            }
            else if (field == "birth" && column != null)
            {
                clients = context.GetClients().Where(t => t.Birth.ToString().Contains(column));
            }
            else if (field == "series" && column != null)
            {
                clients = context.GetClients().Where(t => t.Series.Contains(column));
            }
            else if (field == "number" && column != null)
            {
                clients = context.GetClients().Where(t => t.Number.Contains(column));
            }
            else if (field == "issued_by_whom" && column != null)
            {
                clients = context.GetClients().Where(t => t.Issued_by_whom.Contains(column));
            }
            else if (field == "phone" && column != null)
            {
                clients = context.GetClients().Where(t => t.Phone.Contains(column));
            }
            else if (field == "email" && column != null)
            {
                clients = context.GetClients().Where(t => t.Email.Contains(column));
            }
            return PartialView("_Clients", clients);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Rooms()
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            return View(context.GetRooms());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Rooms(string field, string column)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            IEnumerable<Rooms> rooms = context.GetRooms();
            if (field == "id" && column != null)
            {
                rooms = context.GetRooms().Where(t => t.Id.ToString().Contains(column));
            }
            else if (field == "type" && column != null)
            {
                rooms = context.GetRooms().Where(t => t.Type.Contains(column));
            }
            else if (field == "count" && column != null)
            {
                rooms = context.GetRooms().Where(t => t.Count.ToString().Contains(column));
            }
            else if (field == "status" && column != null)
            {
                rooms = context.GetRooms().Where(t => t.Status.Contains(column));
            }
            else if (field == "price" && column != null)
            {
                rooms = context.GetRooms().Where(t => t.Price.ToString().Contains(column));
            }
            else if (field == "floor" && column != null)
            {
                rooms = context.GetRooms().Where(t => t.Floor.ToString().Contains(column));
            }
            return PartialView("_Rooms", rooms);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Post()
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            return View(context.GetPost());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post(string column)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            IEnumerable<Post> post = context.GetPost();
            if (column != null)
            {
                post = context.GetPost().Where(t => t.Name.Contains(column));
            }
            return PartialView("_Post", post);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Staff()
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            return View(context.GetStaff());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Staff(string field, string column)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            IEnumerable<Staff> staff = context.GetStaff();
            if (field == "fio" && column != null)
            {
                staff = context.GetStaff().Where(t => t.Fio.Contains(column));
            }
            else if (field == "birth" && column != null)
            {
                staff = context.GetStaff().Where(t => t.Birth.ToString().Contains(column));
            }
            else if (field == "series" && column != null)
            {
                staff = context.GetStaff().Where(t => t.Series.Contains(column));
            }
            else if (field == "number" && column != null)
            {
                staff = context.GetStaff().Where(t => t.Number.Contains(column));
            }
            else if (field == "issued_by_whom" && column != null)
            {
                staff = context.GetStaff().Where(t => t.Issued_by_whom.Contains(column));
            }
            else if (field == "phone" && column != null)
            {
                staff = context.GetStaff().Where(t => t.Phone.Contains(column));
            }
            else if (field == "email" && column != null)
            {
                staff = context.GetStaff().Where(t => t.Email.Contains(column));
            }
            else if (field == "id_p" && column != null)
            {
                staff = context.GetStaff().Where(t => t.Id_p.ToString().Contains(column));
            }
            else if (field == "date_of_employment" && column != null)
            {
                staff = context.GetStaff().Where(t => t.Date_of_employment.ToString().Contains(column));
            }
            return PartialView("_Staff", staff);
        }

        [Authorize]
        public IActionResult Service()
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            return View(context.GetService());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Service(string field, string column)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            IEnumerable<Service> service = context.GetService();
            if (field == "name" && column != null)
            {
                service = context.GetService().Where(t => t.Name.Contains(column));
            }
            else if (field == "id_st" && column != null)
            {
                service = context.GetService().Where(t => t.Id_st.ToString().Contains(column));
            }
            else if (field == "id_c" && column != null)
            {
                service = context.GetService().Where(t => t.Id_c.ToString().Contains(column));
            }
            else if (field == "date_of_registration" && column != null)
            {
                service = context.GetService().Where(t => t.Date_of_registration.ToString().Contains(column));
            }
            return PartialView("_Service", service);
        }

        [Authorize]
        public IActionResult Booking()
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            return View(context.GetBooking());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Booking(string field, string column)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            IEnumerable<Booking> booking = context.GetBooking();
            if (field == "id_c" && column != null)
            {
                booking = context.GetBooking().Where(t => t.Id_c.ToString().Contains(column));
            }
            else if (field == "id_r" && column != null)
            {
                booking = context.GetBooking().Where(t => t.Id_r.ToString().Contains(column));
            }
            else if (field == "begin_date" && column != null)
            {
                booking = context.GetBooking().Where(t => t.Begin_date.ToString().Contains(column));
            }
            else if (field == "end_date" && column != null)
            {
                booking = context.GetBooking().Where(t => t.End_date.ToString().Contains(column));
            }
            else if (field == "count_c" && column != null)
            {
                booking = context.GetBooking().Where(t => t.Count_c.ToString().Contains(column));
            }
            return PartialView("_Booking", booking);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Income()
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            return View(context.GetIncome());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Income(string column)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            IEnumerable<Income> income = context.GetIncome();
            if (column != null)
            {
                income = context.GetIncome().Where(t => t.Begin_date.ToString().Contains(column));
            }
            return PartialView("_Income", income);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Guests()
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            return View(context.GetGuests());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Guests(string field, string column)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            IEnumerable<Guests> guests = context.GetGuests();
            if (field == "fio" && column != null)
            {
                guests = context.GetGuests().Where(t => t.Fio.Contains(column));
            }
            else if (field == "id_r" && column != null)
            {
                guests = context.GetGuests().Where(t => t.Id_r.ToString().Contains(column));
            }
            else if (field == "begin_date" && column != null)
            {
                guests = context.GetGuests().Where(t => t.Begin_date.ToString().Contains(column));
            }
            else if (field == "end_date" && column != null)
            {
                guests = context.GetGuests().Where(t => t.End_date.ToString().Contains(column));
            }
            return PartialView("_Guests", guests);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Personal()
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            return View(context.GetPersonal());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Personal(string field, string column)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(HotelContext)) as HotelContext;
            IEnumerable<Personal> personal = context.GetPersonal();
            if (field == "fio" && column != null)
            {
                personal = context.GetPersonal().Where(t => t.Fio.Contains(column));
            }
            else if (field == "name" && column != null)
            {
                personal = context.GetPersonal().Where(t => t.Name.Contains(column));
            }
            else if (field == "date_of_employment" && column != null)
            {
                personal = context.GetPersonal().Where(t => t.Date_of_employment.ToString().Contains(column));
            }
            return PartialView("_Personal", personal);
        }

        [HttpGet]
        public IActionResult InsertClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertClient(Clients model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            if (ModelState.IsValid)
            {
                context.InsertClients(model);
                if (User.IsInRole("User") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Clients");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult InsertRoom()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> InsertRoom(Rooms model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            context.InsertRooms(model);
            return RedirectToAction("Rooms");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult InsertPost()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> InsertPost(Post model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            if (ModelState.IsValid)
            {
                context.InsertPost(model);
                return RedirectToAction("Post");
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult InsertStaff(string fio, string email)
        {
            return View(new Staff {Fio=fio, Email=email });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> InsertStaff(Staff model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            if (ModelState.IsValid)
            {
                try
                {
                    context.InsertStaff(model);
                    return RedirectToAction("Staff");
                }
                catch
                {
                    ModelState.AddModelError("", "Ошибка! Проверьте корректность введённых данных!");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult InsertService()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InsertService(Service model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            if (ModelState.IsValid)
            {
                try
                {
                    context.InsertService(model);
                    return RedirectToAction("Service");
                }
                catch
                {
                    ModelState.AddModelError("", "Ошибка! Проверьте корректность введённых данных!");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult InsertBooking()
        {
            return View(new Booking());    
        }

        [HttpPost]
        public async Task<IActionResult> InsertBooking(Booking model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            if (ModelState.IsValid)
            {
                try
                {
                    context.InsertBooking(model);
                    if(User.IsInRole("User") || User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Booking");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Ошибка! Проверьте корректность введённых данных!");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult UpdateClient(int id)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            return View(context.GetOneClient(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateClient(Clients model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            if (ModelState.IsValid)
            {
                context.UpdateClient(model);
                return RedirectToAction("Clients");
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UpdateRoom(int id)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            return View(context.GetOneRoom(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateRoom(Rooms model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            context.UpdateRoom(model);
            return RedirectToAction("Rooms");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UpdatePost(int id)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            return View(context.GetOnePost(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdatePost(Post model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            if (ModelState.IsValid)
            {
                context.UpdatePost(model);
                return RedirectToAction("Post");
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UpdateStaff(int id)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            return View(context.GetOneStaff(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(Staff model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            if (ModelState.IsValid)
            {
                try
                {
                    context.UpdateStaff(model);
                    return RedirectToAction("Staff");
                }
                catch
                {
                    ModelState.AddModelError("", "Ошибка! Проверьте корректность введённых данных!");
                    return View();
                }            
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            return View(context.GetOneService(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateService(Service model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            if (ModelState.IsValid)
            {
                try
                {
                    context.UpdateService(model);
                    return RedirectToAction("Service");
                }
                catch
                {
                    ModelState.AddModelError("", "Ошибка! Проверьте корректность введённых данных!");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult UpdateBooking(int id)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            return View(context.GetOneBooking(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(Booking model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            if (ModelState.IsValid)
            {
                try
                {
                    context.UpdateBooking(model);
                    return RedirectToAction("Booking");
                }
                catch
                {
                    ModelState.AddModelError("", "Ошибка! Проверьте корректность введённых данных!");
                    return View();
                }              
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteClient(Clients model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            context.DeleteClient(model);
            return RedirectToAction("Clients");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteRoom(Rooms model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            context.DeleteRoom(model);
            return RedirectToAction("Rooms");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeletePost(Post model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            context.DeletePost(model);
            return RedirectToAction("Post");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteStaff(Staff model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            context.DeleteStaff(model);
            return RedirectToAction("Staff");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteService(Service model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            context.DeleteService(model);
            return RedirectToAction("Service");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteBooking(Booking model)
        {
            HotelContext context = HttpContext.RequestServices.GetService(typeof(Hotel.Data.HotelContext)) as HotelContext;
            context.DeleteBooking(model);
            return RedirectToAction("Booking");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return RedirectToAction("Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
