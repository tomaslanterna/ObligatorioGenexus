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
   public class aimpresionentrada : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "EntradaId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9EntradaId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
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

      public aimpresionentrada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aimpresionentrada( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_EntradaId )
      {
         this.AV9EntradaId = aP0_EntradaId;
         initialize();
         executePrivate();
         aP0_EntradaId=this.AV9EntradaId;
      }

      public short executeUdp( )
      {
         execute(ref aP0_EntradaId);
         return AV9EntradaId ;
      }

      public void executeSubmit( ref short aP0_EntradaId )
      {
         aimpresionentrada objaimpresionentrada;
         objaimpresionentrada = new aimpresionentrada();
         objaimpresionentrada.AV9EntradaId = aP0_EntradaId;
         objaimpresionentrada.context.SetSubmitInitialConfig(context);
         objaimpresionentrada.initialize();
         Submit( executePrivateCatch,objaimpresionentrada);
         aP0_EntradaId=this.AV9EntradaId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aimpresionentrada)stateInfo).executePrivate();
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
            AV12GXLvl1 = 0;
            /* Using cursor P000F2 */
            pr_default.execute(0, new Object[] {AV9EntradaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A9ClienteId = P000F2_A9ClienteId[0];
               A1EspectaculoId = P000F2_A1EspectaculoId[0];
               A4LugarId = P000F2_A4LugarId[0];
               A7TipoEspectaculoId = P000F2_A7TipoEspectaculoId[0];
               A27LugarSectorId = P000F2_A27LugarSectorId[0];
               A23EntradaId = P000F2_A23EntradaId[0];
               A40000EspectaculoImagen_GXI = P000F2_A40000EspectaculoImagen_GXI[0];
               A42EntradaFecha = P000F2_A42EntradaFecha[0];
               A30LugarSectorPrecio = P000F2_A30LugarSectorPrecio[0];
               A28LugarSectorName = P000F2_A28LugarSectorName[0];
               A5LugarName = P000F2_A5LugarName[0];
               A16EspectaculoFecha = P000F2_A16EspectaculoFecha[0];
               A10ClienteName = P000F2_A10ClienteName[0];
               A50EspectaculoPaisName = P000F2_A50EspectaculoPaisName[0];
               A8TipoEspectaculoName = P000F2_A8TipoEspectaculoName[0];
               A2EspectaculoName = P000F2_A2EspectaculoName[0];
               A26EspectaculoImagen = P000F2_A26EspectaculoImagen[0];
               A10ClienteName = P000F2_A10ClienteName[0];
               A4LugarId = P000F2_A4LugarId[0];
               A7TipoEspectaculoId = P000F2_A7TipoEspectaculoId[0];
               A40000EspectaculoImagen_GXI = P000F2_A40000EspectaculoImagen_GXI[0];
               A16EspectaculoFecha = P000F2_A16EspectaculoFecha[0];
               A2EspectaculoName = P000F2_A2EspectaculoName[0];
               A26EspectaculoImagen = P000F2_A26EspectaculoImagen[0];
               A5LugarName = P000F2_A5LugarName[0];
               A8TipoEspectaculoName = P000F2_A8TipoEspectaculoName[0];
               A30LugarSectorPrecio = P000F2_A30LugarSectorPrecio[0];
               A28LugarSectorName = P000F2_A28LugarSectorName[0];
               AV12GXLvl1 = 1;
               H0F0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A42EntradaFecha, "99/99/99"), 644, Gx_line+11, 811, Gx_line+26, 2, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : A26EspectaculoImagen);
               getPrinter().GxDrawBitMap(sImgUrl, 22, Gx_line+22, 200, Gx_line+67) ;
               getPrinter().GxDrawText("Entrada", 344, Gx_line+33, 422, Gx_line+56, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha emision", 500, Gx_line+11, 634, Gx_line+33, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               H0F0( false, 362) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), 473, Gx_line+67, 682, Gx_line+82, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8TipoEspectaculoName, "")), 473, Gx_line+133, 682, Gx_line+148, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A50EspectaculoPaisName, "")), 472, Gx_line+267, 681, Gx_line+282, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A10ClienteName, "")), 473, Gx_line+33, 682, Gx_line+48, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A22FuncionName, "")), 473, Gx_line+100, 682, Gx_line+115, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A16EspectaculoFecha, "99/99/99"), 473, Gx_line+167, 667, Gx_line+182, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5LugarName, "")), 472, Gx_line+200, 681, Gx_line+215, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28LugarSectorName, "")), 472, Gx_line+233, 681, Gx_line+248, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9")), 478, Gx_line+300, 667, Gx_line+315, 2, 0, 0, 0) ;
               getPrinter().GxDrawText("Nombre Cliente", 106, Gx_line+33, 289, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Nombre Espectaculo", 106, Gx_line+67, 289, Gx_line+89, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo Espectaculo", 106, Gx_line+133, 289, Gx_line+155, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Espectaculo", 106, Gx_line+167, 267, Gx_line+189, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Lugar Espectaculo", 106, Gx_line+200, 272, Gx_line+227, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Pais ", 106, Gx_line+267, 228, Gx_line+289, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 106, Gx_line+300, 223, Gx_line+322, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Nombre Funcion", 106, Gx_line+100, 289, Gx_line+127, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Sector", 106, Gx_line+233, 239, Gx_line+260, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+362);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV12GXLvl1 == 0 )
            {
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0F0( true, 0) ;
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

      protected void H0F0( bool bFoot ,
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
         P000F2_A9ClienteId = new short[1] ;
         P000F2_A1EspectaculoId = new short[1] ;
         P000F2_A4LugarId = new short[1] ;
         P000F2_A7TipoEspectaculoId = new short[1] ;
         P000F2_A27LugarSectorId = new short[1] ;
         P000F2_A23EntradaId = new short[1] ;
         P000F2_A40000EspectaculoImagen_GXI = new string[] {""} ;
         P000F2_A42EntradaFecha = new DateTime[] {DateTime.MinValue} ;
         P000F2_A30LugarSectorPrecio = new short[1] ;
         P000F2_A28LugarSectorName = new string[] {""} ;
         P000F2_A5LugarName = new string[] {""} ;
         P000F2_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         P000F2_A10ClienteName = new string[] {""} ;
         P000F2_A50EspectaculoPaisName = new string[] {""} ;
         P000F2_A8TipoEspectaculoName = new string[] {""} ;
         P000F2_A2EspectaculoName = new string[] {""} ;
         P000F2_A26EspectaculoImagen = new string[] {""} ;
         A40000EspectaculoImagen_GXI = "";
         A42EntradaFecha = DateTime.MinValue;
         A28LugarSectorName = "";
         A5LugarName = "";
         A16EspectaculoFecha = DateTime.MinValue;
         A10ClienteName = "";
         A50EspectaculoPaisName = "";
         A8TipoEspectaculoName = "";
         A2EspectaculoName = "";
         A26EspectaculoImagen = "";
         sImgUrl = "";
         A22FuncionName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aimpresionentrada__default(),
            new Object[][] {
                new Object[] {
               P000F2_A9ClienteId, P000F2_A1EspectaculoId, P000F2_A4LugarId, P000F2_A7TipoEspectaculoId, P000F2_A27LugarSectorId, P000F2_A23EntradaId, P000F2_A40000EspectaculoImagen_GXI, P000F2_A42EntradaFecha, P000F2_A30LugarSectorPrecio, P000F2_A28LugarSectorName,
               P000F2_A5LugarName, P000F2_A16EspectaculoFecha, P000F2_A10ClienteName, P000F2_A50EspectaculoPaisName, P000F2_A8TipoEspectaculoName, P000F2_A2EspectaculoName, P000F2_A26EspectaculoImagen
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV9EntradaId ;
      private short GxWebError ;
      private short AV12GXLvl1 ;
      private short A9ClienteId ;
      private short A1EspectaculoId ;
      private short A4LugarId ;
      private short A7TipoEspectaculoId ;
      private short A27LugarSectorId ;
      private short A23EntradaId ;
      private short A30LugarSectorPrecio ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string sImgUrl ;
      private DateTime A42EntradaFecha ;
      private DateTime A16EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A40000EspectaculoImagen_GXI ;
      private string A28LugarSectorName ;
      private string A5LugarName ;
      private string A10ClienteName ;
      private string A50EspectaculoPaisName ;
      private string A8TipoEspectaculoName ;
      private string A2EspectaculoName ;
      private string A22FuncionName ;
      private string A26EspectaculoImagen ;
      private IGxDataStore dsDefault ;
      private short aP0_EntradaId ;
      private IDataStoreProvider pr_default ;
      private short[] P000F2_A9ClienteId ;
      private short[] P000F2_A1EspectaculoId ;
      private short[] P000F2_A4LugarId ;
      private short[] P000F2_A7TipoEspectaculoId ;
      private short[] P000F2_A27LugarSectorId ;
      private short[] P000F2_A23EntradaId ;
      private string[] P000F2_A40000EspectaculoImagen_GXI ;
      private DateTime[] P000F2_A42EntradaFecha ;
      private short[] P000F2_A30LugarSectorPrecio ;
      private string[] P000F2_A28LugarSectorName ;
      private string[] P000F2_A5LugarName ;
      private DateTime[] P000F2_A16EspectaculoFecha ;
      private string[] P000F2_A10ClienteName ;
      private string[] P000F2_A50EspectaculoPaisName ;
      private string[] P000F2_A8TipoEspectaculoName ;
      private string[] P000F2_A2EspectaculoName ;
      private string[] P000F2_A26EspectaculoImagen ;
   }

   public class aimpresionentrada__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000F2;
          prmP000F2 = new Object[] {
          new ParDef("@AV9EntradaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000F2", "SELECT T1.[ClienteId], T1.[EspectaculoId], T3.[LugarId], T3.[TipoEspectaculoId], T1.[LugarSectorId], T1.[EntradaId], T3.[EspectaculoImagen_GXI], T1.[EntradaFecha], T6.[LugarSectorPrecio], T6.[LugarSectorName], T4.[LugarName], T3.[EspectaculoFecha], T2.[ClienteName], T1.[EspectaculoPaisName], T5.[TipoEspectaculoName], T3.[EspectaculoName], T3.[EspectaculoImagen] FROM ((((([Entrada] T1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = T1.[ClienteId]) INNER JOIN [Espectaculo] T3 ON T3.[EspectaculoId] = T1.[EspectaculoId]) INNER JOIN [Lugar] T4 ON T4.[LugarId] = T3.[LugarId]) INNER JOIN [TipoEspectaculo] T5 ON T5.[TipoEspectaculoId] = T3.[TipoEspectaculoId]) LEFT JOIN [LugarSector] T6 ON T6.[LugarId] = T3.[LugarId] AND T6.[LugarSectorId] = T1.[LugarSectorId]) WHERE T1.[EntradaId] = @AV9EntradaId ORDER BY T1.[EntradaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F2,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(7));
                return;
       }
    }

 }

}
