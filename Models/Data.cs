using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourSay.Models
{
    public class Data
    {
        static Data instance = null;
        //Create the instance Data()
        Data()
        {
            using (YourSayDB db = new YourSayDB())
            {
                //Create the categories list
                Categories = new List<Category>();
                Categories.Add(new Category { Title = "Animal Rights" });
                Categories.Add(new Category { Title = "Child Abuse" });
                Categories.Add(new Category { Title = "Employee Rights" });
                Categories.Add(new Category { Title = "Environment" });
                Categories.Add(new Category { Title = "Health" });
                Categories.Add(new Category { Title = "Human Rights" });
                Categories.Add(new Category { Title = "Racism" });
                Categories.Add(new Category { Title = "Tax" });
                Categories.Add(new Category { Title = "Other" });


                //Create and save new random causes for our application (this will only be used once)
                
                db.Causes.Add(new Causes { Title = "Say No to Trophy Hunting", Details = "Up to 1.7 MILLION animals have been killed for sport and selfies by Trophy Hunters over the past decade.The UK government is currently holding a Public Consultation on whether to BAN hunting trophies.We call on the UK government to implement OPTION 3 for a Total Ban as a first step towards an END to all Trophy Hunting", Category = "Animal Rights" , Counter = 0});
                db.Causes.Add(new Causes { Title = "Give People a Final Say on Brexit Deal", Details = "Regardless of how you voted in the Brexit referendum, you deserve a say on the final deal.", Category = "Human Rights", Counter = 0});
                db.Causes.Add(new Causes { Title = "Stop the inhuman treatment of doctors", Details = "Doctors who are accused of misconduct are being treated as guilty before any investigation, by their employer and the GMC. There is little or no protection for these doctors. This must be stopped.", Category = "Human Rights", Counter = 0});
                db.Causes.Add(new Causes { Title = "Stop the cruel killing of squirrels in London's Royal Parks", Details = "Whatever your personal view on grey squirrels, they do not deserve to be killed, as there are other non-lethal alternatives available.", Category = "Animal Rights", Counter = 0 });
                db.Causes.Add(new Causes { Title = "We need a UK-wide Climate Emergency Action Plan!", Details = "The UK has declared a climate emergency - now it is time to take emergency action. It is clear that unless we do, we face the gravest threats in human history.", Category = "Environment", Counter = 0 });
                db.Causes.Add(new Causes { Title = "Abolish IR35 and halt IR35 reforms due in April 2020", Details = "This petition is on behalf of Contractors/Freelancers urging government to abolish IR35 and to undertake a holistic review of tax on freelancers. We request government to halt IR35 reforms in private sector due in April 2020 as an urgent first step.", Category = "Employee Rights", Counter = 0 });
                db.Causes.Add(new Causes { Title = "Save the Scottish wildcat by protecting Clashindarroch Forest!", Details = "The Scottish Wildcat is one of the rarest animals in the world; there are only 35 of them left on earth. Please sign our petition urgently calling on the Scottish Government to immediately halt the logging and exploitation of Clashindarroch Forest to ensure the iconic Scottish wildcat survives.", Category = "Animal Rights", Counter = 0 });
                db.Causes.Add(new Causes { Title = "Free Dental Treatment for All Cancer Patients", Details = "Many cancer patients, who have previously had little or no dental issues, experience loss or crumbling of teeth together with a whole host of other dental problems that occur during or after treatment for cancer. The cost of dental work can be overwhelming, even with care on the NHS. That\'s why I\'m asking the Government to introduce free dental care for cancer patients.", Category = "Health", Counter = 0 });
                db.Causes.Add(new Causes { Title = "Zero Tolerance for Racism in the School", Details = "No child should have to go to school in fear of being assaulted, harassed, or degraded because of their skin color, ethnicity, sexual orientation, religion, and so forth. We\'re calling for stiffer consequences because, let\'s face it, a suspension is just not enough!", Category = "Human Rights", Counter = 0 });

                db.userAccount.RemoveRange(db.userAccount);
                //Save changes (This will be only used once
                db.SaveChanges();
                

                //Remove all causes at once(only if needed)

                //db.Causes.RemoveRange(db.Causes);
                //db.userAccount.RemoveRange(db.userAccount);
                //db.SaveChanges();


            }
        }

        public static Data Instance
        {
            get
            {
                //Check if instance exists, if not create a new Data()
                if (instance == null) instance = new Data();
                return instance;
            }
        }
        public List<Category> Categories { get; set; }
    }
}