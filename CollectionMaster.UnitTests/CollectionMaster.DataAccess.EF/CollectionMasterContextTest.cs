using System;
using System.Linq;
using CollectionMaster.DataAccess.EF.Context;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionMaster.UnitTests.CollectionMaster.DataAccess.EF
{
    [TestClass]
    public class CollectionMasterContextTest
    {
        [TestMethod]
        public void GetAlbumsTest()
        {
            var result = true;
            try
            {
                using (var context = new CollectionMasterContext())
                {
                    var search = context.Albums;
                }
            }
            catch (Exception)
            {
                result = false;
            }

            Assert.IsTrue(result);
        }
    }
}
