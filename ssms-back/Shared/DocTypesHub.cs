using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SSMS.EntityModels;

namespace SSMS
{
  public class DocTypesHub : BaseHub<DocType, Byte>
  {
    private BaseService<DocType, Byte> _DocTypeSrv { get; }
    // in constructor take BaseService from DI
    // and setting its [TEntity,TKey] to [DocType, Byte] to Act as docTypesService
    // and take ado object from DI [used in Auto Generate New Ids in Add Method]
    // finally pass SQL [TableName, PK ColumnName] to BaseHub
    public DocTypesHub(BaseService<DocType, Byte> docTypesService, Ado ado)
                            : base(docTypesService, "docTypes", "docTypeId", ado)
    {
      _DocTypeSrv = docTypesService;
    }
  }
}
