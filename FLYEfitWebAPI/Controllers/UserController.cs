using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IO.Swagger.Controllers;
using IO.Swagger.Models;
using MySql.Data.MySqlClient;

namespace FLYEfitWebAPI.Controllers
{
    [Produces("application/json")]
    //[Route("api/[controller]")]
    //[Route("/api/users")]
    public class UserController : UserApiController
    {
        Database_MySQL db = new Database_MySQL();

        //[Route("gyms")]
        [Route("/api/v1/gyms")]
        public override IActionResult GetGyms()
        {
            List<Gym> gymList = new List<Gym>();
            GymCollection gyms = new GymCollection(gymList);

            db.open();
            MySqlDataReader theReader = db.getData("Select id, gym_name as name, gym_status as status, presale_Status as preSalesStatus, opening_date as openDate, gps_latitude as latitude, gps_longitude as longitude, photo from ff_gyms;");
            while (theReader.Read())
            {
                Gym gym = new Gym(int.Parse(theReader["id"].ToString()),
                                    theReader["name"].ToString(),
                                    int.Parse(theReader["status"].ToString()),
                                    int.Parse(theReader["preSalesStatus"].ToString()),
                                    DateTime.Parse(theReader["openDate"].ToString()),
                                    double.Parse(theReader["latitude"].ToString()),
                                    double.Parse(theReader["longitude"].ToString()),
                                    theReader["photo"].ToString());
                gymList.Add(gym);
            }
            db.close();

            return new ObjectResult(gyms);
        }


        [Route("/api/v1/member/login")]
        public override IActionResult MemberLogin(string emailAddress, string password)
        {
            
            db.open();

            string query = "";
            query = "SELECT m.id memberID, u.first_name firstName, u.last_name lastName, u.email_address emailAddress, m.Access_Code accessCode, m.address_1 address1, ";
            query += "m.address_2 address2, m.address_3 address3, m.post_code postCode, m.phone_mobile phoneMobile, m.phone_daytime phoneDaytime, gym_id homeGymId, ";
            query += "m.join_success_datetime joinDate, title_id title, m.location_id location, m.gender_id gender, u.role_id role, m.gym_intro_taken gymIntroTaken, ";
            query += "m.gym_intro_taken_date gymIntroTakenDate,u.user_status_id 'status', u.password, u.salt ";
            query += "FROM(ff_users u) ";
            query += "INNER JOIN(ff_members m) ON m.user_id = u.id";
            query += "WHERE u.email_address = @emailAddress";
            
            Dictionary<string, string> myParams = new Dictionary<string, string>();
            myParams.Add("@emailAddress", emailAddress);

            MySqlDataReader theReader = db.getData(query, myParams);
            while (theReader.Read())
            {
                //theReader["id"]
                Member member = new Member(int.Parse(theReader["memberId"].ToString()),
                                            theReader["firstName"].ToString(),
                                            theReader["lastName"].ToString(),
                                            theReader["emailAddress"].ToString(),
                                            theReader["accessCode"].ToString(),
                                            theReader["address1"].ToString(),
                                            theReader["address2"].ToString(),
                                            theReader["address3"].ToString(),
                                            theReader["postCode"].ToString(),
                                            theReader["phoneMobile"].ToString(),
                                            theReader["phoneDaytime"].ToString(),
                                            int.Parse(theReader["homeGymId"].ToString()),
                                            DateTime.Parse(theReader["joinDate"].ToString())
                                            //new MemberTitle(int.Parse(theReader["title"].ToString())),
                                            //new Location(int.Parse(theReader["location"].ToString())),
                                            //new Gender(int.Parse(theReader["gender"].ToString())),
                                            //new Role(int.Parse(theReader["role"].ToString())),
                                            ////theReader["gymIntroTaken"].ToString(),
                                            //new UserStatus(int.Parse(theReader["status"].ToString()))
                                            );
            }
            db.close();

            //return new ObjectResult(member);
            return new ObjectResult("test");
        }

    }
}