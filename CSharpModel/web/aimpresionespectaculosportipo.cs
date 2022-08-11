using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aimpresionespectaculosportipo : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public aimpresionespectaculosportipo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aimpresionespectaculosportipo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         aimpresionespectaculosportipo objaimpresionespectaculosportipo;
         objaimpresionespectaculosportipo = new aimpresionespectaculosportipo();
         objaimpresionespectaculosportipo.context.SetSubmitInitialConfig(context);
         objaimpresionespectaculosportipo.initialize();
         Submit( executePrivateCatch,objaimpresionespectaculosportipo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aimpresionespectaculosportipo)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV4GXLvl5 = 0;
            /* Using cursor P000G2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK0G3 = false;
               A4LugarId = P000G2_A4LugarId[0];
               A3PaisId = P000G2_A3PaisId[0];
               A7TipoEspectaculoId = P000G2_A7TipoEspectaculoId[0];
               A6PaisName = P000G2_A6PaisName[0];
               A5LugarName = P000G2_A5LugarName[0];
               A16EspectaculoFecha = P000G2_A16EspectaculoFecha[0];
               A2EspectaculoName = P000G2_A2EspectaculoName[0];
               A1EspectaculoId = P000G2_A1EspectaculoId[0];
               A8TipoEspectaculoName = P000G2_A8TipoEspectaculoName[0];
               A3PaisId = P000G2_A3PaisId[0];
               A5LugarName = P000G2_A5LugarName[0];
               A6PaisName = P000G2_A6PaisName[0];
               A8TipoEspectaculoName = P000G2_A8TipoEspectaculoName[0];
               AV4GXLvl5 = 1;
               H0G0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8TipoEspectaculoName, "")), 244, Gx_line+33, 561, Gx_line+48, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               AV5GXLvl8 = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P000G2_A7TipoEspectaculoId[0] == A7TipoEspectaculoId ) )
               {
                  BRK0G3 = false;
                  A4LugarId = P000G2_A4LugarId[0];
                  A3PaisId = P000G2_A3PaisId[0];
                  A6PaisName = P000G2_A6PaisName[0];
                  A5LugarName = P000G2_A5LugarName[0];
                  A16EspectaculoFecha = P000G2_A16EspectaculoFecha[0];
                  A2EspectaculoName = P000G2_A2EspectaculoName[0];
                  A1EspectaculoId = P000G2_A1EspectaculoId[0];
                  A3PaisId = P000G2_A3PaisId[0];
                  A5LugarName = P000G2_A5LugarName[0];
                  A6PaisName = P000G2_A6PaisName[0];
                  AV5GXLvl8 = 1;
                  H0G0( false, 100) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Id Espectaculo", 33, Gx_line+56, 161, Gx_line+89, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Nombre Espectaculo", 172, Gx_line+56, 350, Gx_line+78, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Fecha Espectaculo", 356, Gx_line+56, 512, Gx_line+89, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Pais Espectaculo", 667, Gx_line+56, 817, Gx_line+78, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Lugar Espectaculo", 522, Gx_line+56, 666, Gx_line+83, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  H0G0( false, 100) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9")), 56, Gx_line+45, 150, Gx_line+60, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), 194, Gx_line+45, 333, Gx_line+60, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A16EspectaculoFecha, "99/99/99"), 378, Gx_line+45, 500, Gx_line+60, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5LugarName, "")), 544, Gx_line+45, 644, Gx_line+60, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), 706, Gx_line+45, 773, Gx_line+60, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  BRK0G3 = true;
                  pr_default.readNext(0);
               }
               if ( AV5GXLvl8 == 0 )
               {
               }
               if ( ! BRK0G3 )
               {
                  BRK0G3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            if ( AV4GXLvl5 == 0 )
            {
               H0G0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("No hay espectaculos", 289, Gx_line+33, 633, Gx_line+66, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0G0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0G0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Espectaculos Por Tipo", 222, Gx_line+11, 633, Gx_line+67, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P000G2_A4LugarId = new short[1] ;
         P000G2_A3PaisId = new short[1] ;
         P000G2_A7TipoEspectaculoId = new short[1] ;
         P000G2_A6PaisName = new string[] {""} ;
         P000G2_A5LugarName = new string[] {""} ;
         P000G2_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         P000G2_A2EspectaculoName = new string[] {""} ;
         P000G2_A1EspectaculoId = new short[1] ;
         P000G2_A8TipoEspectaculoName = new string[] {""} ;
         A6PaisName = "";
         A5LugarName = "";
         A16EspectaculoFecha = DateTime.MinValue;
         A2EspectaculoName = "";
         A8TipoEspectaculoName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aimpresionespectaculosportipo__default(),
            new Object[][] {
                new Object[] {
               P000G2_A4LugarId, P000G2_A3PaisId, P000G2_A7TipoEspectaculoId, P000G2_A6PaisName, P000G2_A5LugarName, P000G2_A16EspectaculoFecha, P000G2_A2EspectaculoName, P000G2_A1EspectaculoId, P000G2_A8TipoEspectaculoName
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV4GXLvl5 ;
      private short A4LugarId ;
      private short A3PaisId ;
      private short A7TipoEspectaculoId ;
      private short A1EspectaculoId ;
      private short AV5GXLvl8 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime A16EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK0G3 ;
      private string A6PaisName ;
      private string A5LugarName ;
      private string A2EspectaculoName ;
      private string A8TipoEspectaculoName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000G2_A4LugarId ;
      private short[] P000G2_A3PaisId ;
      private short[] P000G2_A7TipoEspectaculoId ;
      private string[] P000G2_A6PaisName ;
      private string[] P000G2_A5LugarName ;
      private DateTime[] P000G2_A16EspectaculoFecha ;
      private string[] P000G2_A2EspectaculoName ;
      private short[] P000G2_A1EspectaculoId ;
      private string[] P000G2_A8TipoEspectaculoName ;
   }

   public class aimpresionespectaculosportipo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT T1.[LugarId], T2.[PaisId], T1.[TipoEspectaculoId], T3.[PaisName], T2.[LugarName], T1.[EspectaculoFecha], T1.[EspectaculoName], T1.[EspectaculoId], T4.[TipoEspectaculoName] FROM ((([Espectaculo] T1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = T1.[LugarId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) INNER JOIN [TipoEspectaculo] T4 ON T4.[TipoEspectaculoId] = T1.[TipoEspectaculoId]) ORDER BY T1.[TipoEspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
       }
    }

 }

}
