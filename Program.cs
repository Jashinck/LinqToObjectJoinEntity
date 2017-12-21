using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToObjectJoinEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MyObject> myObjects = new List<MyObject>();
            myObjects.Add(new MyObject { Identity = 1, Name = "Jack", Age = 30 });
            myObjects.Add(new MyObject { Identity = 2, Name = "Sam", Age = 28 });
            myObjects.Add(new MyObject { Identity = 3, Name = "Lucy", Age = 23 });

            #region Create Data

            //using (var db = new EntityContext())
            //{
            //    db.Entitys.Add(new Entity { EntityId = 1, Name = "Entity", Notes = "Notes" });
            //    db.Entitys.Add(new Entity { EntityId = 2, Name = "Frame", Notes = "Mates" });
            //    db.Entitys.Add(new Entity { EntityId = 3, Name = "Work", Notes = "Honor" });

            //    db.SaveChanges();
            //}

            #endregion

            using (var db = new EntityContext())
            {
                #region Reproduce Linq Problem

                #region Reproduce Linq to Object Join Linq to Entity

                var objectNames = (from myObject in myObjects
                                   join entity in db.Entitys
                                   on myObject.Identity equals entity.EntityId
                                   select myObject.Name).ToList();

                #endregion

                #region Reproduce Linq to Entity Join Linq to Object

                //var entityName = (from entity in db.Entitys
                //                  join myObject in myObjects
                //                  on entity.EntityId equals myObject.Identity
                //                  select entity.Name).ToList();

                #endregion

                #endregion
                
                #region Linq to Entity Join Linq to Object(Resolve)

                //var identities = myObjects.Select(o => o.Identity);

                //var entitytNames = (from entity in db.Entitys
                //                    join identity in identities
                //                    on entity.EntityId equals identity
                //                    select entity.Name).ToList();

                #endregion

                foreach (var name in objectNames)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }

    #region Object

    public class MyObject
    {
        public int Identity { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    #endregion
}
