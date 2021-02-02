using Flats.SharedModel.FlatImageSharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.BusinessLogic.FlatImageBusiness
{
    public interface IFlatImageBusiness
    {
        FlatImageSharedModel GetProfilePicture(Guid flatId);
        void AddImage(FlatImageSharedModel flatImageSharedModel);
        void AddProfilePicture(FlatImageSharedModel flatImageSharedModel);
        void AddRoomImage(FlatImageSharedModel flatImageSharedModel, string[] ImageUrl);
    }
}
