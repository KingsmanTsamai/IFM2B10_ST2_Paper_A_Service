using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IFM2B10_ST2_Paper_A_Service
{
    public class PaperAService : IPaperAService
    {
        DataClasses1DataContext db=new DataClasses1DataContext();

        public List<itemMenu> getmealType()
        {
            dynamic meals=new List<itemMenu>();
            var mealType = (from p in db.itemMenus
                                where p.Active.Equals(1)
                                select p).DefaultIfEmpty();
            foreach(itemMenu p in mealType)
            {
                var newItem=new itemMenu() { 
                
                   Name=p.Name,
                   Price=p.Price,
                   Category=p.Category,
                   Image=p.Image,
                   Description=p.Description,
                   OnSpecial=p.OnSpecial,
                   Id=p.Id,

                };
                meals.Add(p);
            }
            return meals;
        }

        public List<Item> getOEI()
        {
           dynamic items=new List<Item>();
            dynamic item = (from o in db.Items
                            where o.Active.Equals(1)
                            select o).DefaultIfEmpty();
            foreach (Item o in item) { 
               items.Add(o);
            }
            return items;
        }

        public itemMenu getSingleProduct(int ID)
        {
            var item = (from p in db.itemMenus
                        where p.Id.Equals(ID)
                        select p).FirstOrDefault();

            if (item == null)
            {

                return null;
            }
            else { 
            return item;
            }
        }

        public bool addBooking(string name, string email, int persons, string phone, DateTime mydate, string time, string note)
        {
            var newReservation = new Reservation() { 
                Name = name,
                Email = email,
                Persons = persons,
                Date = mydate,
                Time = time,
                Note = note,
                Phone = phone
            };
            db.Reservations.InsertOnSubmit(newReservation);
            try {
                db.SubmitChanges();
                return true;

            } catch (Exception ex) { 
                ex.GetBaseException();
                return false;
            }
        }

        public bool checkIfExist(string email)
        {
            var mail = (from p in db.Reservations
                        where p.Email.Equals(email)
                        select p).FirstOrDefault();
            if (mail == null)
            {
                return false;
            }
            else
            {
                return true;

            }
        }

        public Reservation getEmail(int ID)
        {
            var user = (from p in db.Reservations
                        where p.Id.Equals(ID)
                        select p).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else {
                return user;
            
            }
        }

        public bool editReservation(string name, string email, int persons, string phone, DateTime mydate, string time, string note)
        {
            var newReservation = new Reservation()
            {
                Name = name,
                Email = email,
                Persons = persons,
                Date = mydate,
                Time = time,
                Note = note,
                Phone = phone
            };
           // db.Reservations.InsertOnSubmit(newReservation);
            try
            {
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }
    }
}
