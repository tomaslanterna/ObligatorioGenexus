using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class gxrtctls : GXProcedure
   {
      public gxrtctls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gxrtctls( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         initialize();
         executePrivate();
         aP0_Status=this.AV2Status;
      }

      public short executeUdp( )
      {
         execute(out aP0_Status);
         return AV2Status ;
      }

      public void executeSubmit( out short aP0_Status )
      {
         gxrtctls objgxrtctls;
         objgxrtctls = new gxrtctls();
         objgxrtctls.AV2Status = 0 ;
         objgxrtctls.context.SetSubmitInitialConfig(context);
         objgxrtctls.initialize();
         Submit( executePrivateCatch,objgxrtctls);
         aP0_Status=this.AV2Status;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gxrtctls)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV2Status = 0;
         Console.WriteLine( "=== Starting run time controls" );
         Console.WriteLine( "Checking that table Venta does NOT contain records." );
         AV3NotFound = 0;
         AV6GXLvl5 = 0;
         /* Using cursor LTCTLS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1EspectaculoId = LTCTLS2_A1EspectaculoId[0];
            A11VentaId = LTCTLS2_A11VentaId[0];
            AV6GXLvl5 = 1;
            AV7GXLvl8 = 0;
            /* Using cursor LTCTLS3 */
            pr_default.execute(1, new Object[] {A1EspectaculoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A31EspectaculoSectorId = LTCTLS3_A31EspectaculoSectorId[0];
               AV7GXLvl8 = 1;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV7GXLvl8 == 0 )
            {
               AV2Status = 1;
               Console.WriteLine( "Fail: Table Venta has records but referenced key value in table EspectaculoSector does _not_ exist." );
               Console.WriteLine( "Recovery: See recovery information for reorganization message rgz0029." );
               AV3NotFound = 1;
            }
            if ( AV3NotFound == 1 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV6GXLvl5 == 0 )
         {
            Console.WriteLine( "Success: Table Venta does NOT have records." );
            AV3NotFound = 1;
         }
         if ( AV3NotFound == 0 )
         {
            Console.WriteLine( "Success: Table Ventahas records but all referenced key values in table EspectaculoSector exist." );
         }
         Console.WriteLine( "====================" );
         Console.WriteLine( "=== End of run time controls" );
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         scmdbuf = "";
         LTCTLS2_A1EspectaculoId = new short[1] ;
         LTCTLS2_A11VentaId = new short[1] ;
         LTCTLS3_A1EspectaculoId = new short[1] ;
         LTCTLS3_A31EspectaculoSectorId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gxrtctls__default(),
            new Object[][] {
                new Object[] {
               LTCTLS2_A1EspectaculoId, LTCTLS2_A11VentaId
               }
               , new Object[] {
               LTCTLS3_A1EspectaculoId, LTCTLS3_A31EspectaculoSectorId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV2Status ;
      private short AV3NotFound ;
      private short AV6GXLvl5 ;
      private short A1EspectaculoId ;
      private short A11VentaId ;
      private short AV7GXLvl8 ;
      private short A31EspectaculoSectorId ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] LTCTLS2_A1EspectaculoId ;
      private short[] LTCTLS2_A11VentaId ;
      private short[] LTCTLS3_A1EspectaculoId ;
      private short[] LTCTLS3_A31EspectaculoSectorId ;
      private short aP0_Status ;
   }

   public class gxrtctls__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmLTCTLS2;
          prmLTCTLS2 = new Object[] {
          };
          Object[] prmLTCTLS3;
          prmLTCTLS3 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("LTCTLS2", "SELECT DISTINCT [EspectaculoId], [VentaId] FROM [Venta] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("LTCTLS3", "SELECT [EspectaculoId], [EspectaculoSectorId] FROM [EspectaculoSector] WHERE ([EspectaculoId] = @EspectaculoId) AND ([EspectaculoSectorId] = 0) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS3,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
