using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLibs.AzureBlobStorage.Utils.Exceptions
{
    public class AzureBlobStorageException: Exception
    {
        public AzureBlobStorageException(string message)
           : base(message)
        {

        }
    }
}
