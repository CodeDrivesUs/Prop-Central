using Flats.DataModel.Amenities;
using Flats.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.DataRepository.AmenitiesDataRepository
{
   public  class AmenitiesDataRepository:IAmenitiesDataRepository
    {
        private IRepository _repository;

        public AmenitiesDataRepository()
        {
            _repository = new Repository.Repository();
        }

       
        public void Add(Amenities model)
        {
            var query = string.Format(@"INSERT INTO [dbo].[Amenities]  ([Name],[ImageUrl]) VALUES ('{0}','{1}')", model.Name, model.ImageUrl);
            _repository.ExecuteNonQuery(query, null, CommandType.Text);
        }
        public void Update(Amenities model)
        {
            var query = string.Format(@"UPDATE [dbo].[Amenities]  SET [Name] = '{0}'  ,[ImageUrl] = '{1}'WHERE  AmenitieID= {2}", model.Name,  model.ImageUrl, model.Id);
            _repository.ExecuteNonQuery(query, null, CommandType.Text);
        }

        public void Delete(int id)
        {
            var query = string.Format(@"DELETE  FROM  [dbo].[Amenities] WHERE [Id] = '{0}'", id);
            _repository.ExecuteNonQuery(query, null, CommandType.Text);
        }


        public Amenities Get(int id)
        {
            var query = string.Format(@"SELECT * FROM  [dbo].[Amenities] WHERE [Id] = '{0}'", id);
            var results = _repository.SelectOne<Amenities>(query, null, CommandType.Text);
            return results;
        }

        public IEnumerable<Amenities> GetAll()
        {
            var query = @"SELECT * FROM [dbo].[Amenities] ORDER BY Id;";
            var results = _repository.Query<Amenities>(query, null, CommandType.Text);
            return results;
        }
    }
}
