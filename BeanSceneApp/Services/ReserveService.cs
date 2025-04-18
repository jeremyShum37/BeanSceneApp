using BeanSceneApp.Data;
using BeanSceneApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BeanSceneApp.Services
{
    public class ReserveService : AbstrReservService, InterReservService
    {
        private BeanSceneAppContext _DB;
        public ReserveService(BeanSceneAppContext DB)
        {
            _DB = DB;
        }

        public string CreateReservation(Reservation r)
        {
            _DB.Add(r);
            _DB.SaveChanges();
            return "Reservation Has Been Created Successfully";
        }

        public override string EditReservation(Reservation r)
        {
            _DB.Update(r);
            _DB.SaveChanges();
            return "Reservation Has Been Updated Successfully";
        }
    }
}
