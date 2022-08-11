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
   public class aimpresionespectaculosfecha : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "FechaRecibida");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8FechaRecibida = context.localUtil.ParseDateParm( gxfirstwebparm);
            }
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

      public aimpresionespectaculosfecha( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aimpresionespectaculosfecha( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FechaRecibida )
      {
         this.AV8FechaRecibida = aP0_FechaRecibida;
         initialize();
         executePrivate();
         aP0_FechaRecibida=this.AV8FechaRecibida;
      }

      public DateTime executeUdp( )
      {
         execute(ref aP0_FechaRecibida);
         return AV8FechaRecibida ;
      }

      public void executeSubmit( ref DateTime aP0_FechaRecibida )
      {
         aimpresionespectaculosfecha objaimpresionespectaculosfecha;
         objaimpresionespectaculosfecha = new aimpresionespectaculosfecha();
         objaimpresionespectaculosfecha.AV8FechaRecibida = aP0_FechaRecibida;
         objaimpresionespectaculosfecha.context.SetSubmitInitialConfig(context);
         objaimpresionespectaculosfecha.initialize();
         Submit( executePrivateCatch,objaimpresionespectaculosfecha);
         aP0_FechaRecibida=this.AV8FechaRecibida;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aimpresionespectaculosfecha)stateInfo).executePrivate();
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
            AV11GXLvl4 = 0;
            /* Using cursor P000I2 */
            pr_default.execute(0, new Object[] {AV8FechaRecibida});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A4LugarId = P000I2_A4LugarId[0];
               A3PaisId = P000I2_A3PaisId[0];
               A7TipoEspectaculoId = P000I2_A7TipoEspectaculoId[0];
               A16EspectaculoFecha = P000I2_A16EspectaculoFecha[0];
               A8TipoEspectaculoName = P000I2_A8TipoEspectaculoName[0];
               A6PaisName = P000I2_A6PaisName[0];
               A5LugarName = P000I2_A5LugarName[0];
               A2EspectaculoName = P000I2_A2EspectaculoName[0];
               A1EspectaculoId = P000I2_A1EspectaculoId[0];
               A3PaisId = P000I2_A3PaisId[0];
               A5LugarName = P000I2_A5LugarName[0];
               A6PaisName = P000I2_A6PaisName[0];
               A8TipoEspectaculoName = P000I2_A8TipoEspectaculoName[0];
               AV11GXLvl4 = 1;
               H0I0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nombre", 72, Gx_line+33, 155, Gx_line+66, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 278, Gx_line+33, 361, Gx_line+66, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Lugar", 456, Gx_line+33, 539, Gx_line+66, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Pais", 622, Gx_line+33, 705, Gx_line+66, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               H0I0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), 44, Gx_line+33, 155, Gx_line+48, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A16EspectaculoFecha, "99/99/99"), 267, Gx_line+33, 373, Gx_line+48, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5LugarName, "")), 450, Gx_line+33, 538, Gx_line+48, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), 628, Gx_line+33, 711, Gx_line+48, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV11GXLvl4 == 0 )
            {
               H0I0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("No hay Conciertos", 300, Gx_line+33, 511, Gx_line+66, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0I0( true, 0) ;
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

      protected void H0I0( bool bFoot ,
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
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Conciertos", 172, Gx_line+22, 405, Gx_line+72, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Filtrado por Fecha", 489, Gx_line+44, 633, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV8FechaRecibida, "99/99/99"), 678, Gx_line+56, 795, Gx_line+71, 2, 0, 0, 0) ;
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
         P000I2_A4LugarId = new short[1] ;
         P000I2_A3PaisId = new short[1] ;
         P000I2_A7TipoEspectaculoId = new short[1] ;
         P000I2_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         P000I2_A8TipoEspectaculoName = new string[] {""} ;
         P000I2_A6PaisName = new string[] {""} ;
         P000I2_A5LugarName = new string[] {""} ;
         P000I2_A2EspectaculoName = new string[] {""} ;
         P000I2_A1EspectaculoId = new short[1] ;
         A16EspectaculoFecha = DateTime.MinValue;
         A8TipoEspectaculoName = "";
         A6PaisName = "";
         A5LugarName = "";
         A2EspectaculoName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aimpresionespectaculosfecha__default(),
            new Object[][] {
                new Object[] {
               P000I2_A4LugarId, P000I2_A3PaisId, P000I2_A7TipoEspectaculoId, P000I2_A16EspectaculoFecha, P000I2_A8TipoEspectaculoName, P000I2_A6PaisName, P000I2_A5LugarName, P000I2_A2EspectaculoName, P000I2_A1EspectaculoId
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
      private short AV11GXLvl4 ;
      private short A4LugarId ;
      private short A3PaisId ;
      private short A7TipoEspectaculoId ;
      private short A1EspectaculoId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV8FechaRecibida ;
      private DateTime A16EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A8TipoEspectaculoName ;
      private string A6PaisName ;
      private string A5LugarName ;
      private string A2EspectaculoName ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FechaRecibida ;
      private IDataStoreProvider pr_default ;
      private short[] P000I2_A4LugarId ;
      private short[] P000I2_A3PaisId ;
      private short[] P000I2_A7TipoEspectaculoId ;
      private DateTime[] P000I2_A16EspectaculoFecha ;
      private string[] P000I2_A8TipoEspectaculoName ;
      private string[] P000I2_A6PaisName ;
      private string[] P000I2_A5LugarName ;
      private string[] P000I2_A2EspectaculoName ;
      private short[] P000I2_A1EspectaculoId ;
   }

   public class aimpresionespectaculosfecha__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000I2;
          prmP000I2 = new Object[] {
          new ParDef("@AV8FechaRecibida",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000I2", "SELECT T1.[LugarId], T2.[PaisId], T1.[TipoEspectaculoId], T1.[EspectaculoFecha], T4.[TipoEspectaculoName], T3.[PaisName], T2.[LugarName], T1.[EspectaculoName], T1.[EspectaculoId] FROM ((([Espectaculo] T1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = T1.[LugarId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) INNER JOIN [TipoEspectaculo] T4 ON T4.[TipoEspectaculoId] = T1.[TipoEspectaculoId]) WHERE (T4.[TipoEspectaculoName] = 'Concierto') AND (T1.[EspectaculoFecha] = @AV8FechaRecibida) ORDER BY T1.[EspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                return;
       }
    }

 }

}
