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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gx00c1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00c1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx00c1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_pEspectaculoId ,
                           out short aP1_pEspectaculoSectorId )
      {
         this.AV11pEspectaculoId = aP0_pEspectaculoId;
         this.AV12pEspectaculoSectorId = 0 ;
         executePrivate();
         aP1_pEspectaculoSectorId=this.AV12pEspectaculoSectorId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pEspectaculoId");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pEspectaculoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pEspectaculoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV11pEspectaculoId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV11pEspectaculoId", StringUtil.LTrimStr( (decimal)(AV11pEspectaculoId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12pEspectaculoSectorId = (short)(NumberUtil.Val( GetPar( "pEspectaculoSectorId"), "."));
                  AssignAttri("", false, "AV12pEspectaculoSectorId", StringUtil.LTrimStr( (decimal)(AV12pEspectaculoSectorId), 4, 0));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_64 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."));
         nGXsfl_64_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."));
         AV6cEspectaculoSectorId = (short)(NumberUtil.Val( GetPar( "cEspectaculoSectorId"), "."));
         AV7cEspectaculoSectorName = GetPar( "cEspectaculoSectorName");
         AV8cEspectaculoSectorCantidadAsientos = (short)(NumberUtil.Val( GetPar( "cEspectaculoSectorCantidadAsientos"), "."));
         AV9cEspectaculoSectorEstadoSector = (short)(NumberUtil.Val( GetPar( "cEspectaculoSectorEstadoSector"), "."));
         AV10cEspectaculoSectorPrecio = (short)(NumberUtil.Val( GetPar( "cEspectaculoSectorPrecio"), "."));
         AV11pEspectaculoId = (short)(NumberUtil.Val( GetPar( "pEspectaculoId"), "."));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoSectorId, AV7cEspectaculoSectorName, AV8cEspectaculoSectorCantidadAsientos, AV9cEspectaculoSectorEstadoSector, AV10cEspectaculoSectorPrecio, AV11pEspectaculoId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA1I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1I2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 552120), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2022882235748", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00c1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pEspectaculoId,4,0)),UrlEncode(StringUtil.LTrimStr(AV12pEspectaculoSectorId,4,0))}, new string[] {"pEspectaculoId","pEspectaculoSectorId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCESPECTACULOSECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cEspectaculoSectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCESPECTACULOSECTORNAME", AV7cEspectaculoSectorName);
         GxWebStd.gx_hidden_field( context, "GXH_vCESPECTACULOSECTORCANTIDADASIENTOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cEspectaculoSectorCantidadAsientos), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCESPECTACULOSECTORESTADOSECTOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cEspectaculoSectorEstadoSector), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCESPECTACULOSECTORPRECIO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cEspectaculoSectorPrecio), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPESPECTACULOSECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pEspectaculoSectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOSECTORIDFILTERCONTAINER_Class", StringUtil.RTrim( divEspectaculosectoridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOSECTORNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divEspectaculosectornamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER_Class", StringUtil.RTrim( divEspectaculosectorcantidadasientosfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER_Class", StringUtil.RTrim( divEspectaculosectorestadosectorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOSECTORPRECIOFILTERCONTAINER_Class", StringUtil.RTrim( divEspectaculosectorpreciofiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE1I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1I2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx00c1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pEspectaculoId,4,0)),UrlEncode(StringUtil.LTrimStr(AV12pEspectaculoSectorId,4,0))}, new string[] {"pEspectaculoId","pEspectaculoSectorId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00C1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Sector" ;
      }

      protected void WB1I0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEspectaculosectoridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEspectaculosectoridfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblespectaculosectoridfilter_Internalname, "Espectaculo Sector Id", "", "", lblLblespectaculosectoridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCespectaculosectorid_Internalname, "Espectaculo Sector Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCespectaculosectorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cEspectaculoSectorId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCespectaculosectorid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cEspectaculoSectorId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cEspectaculoSectorId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCespectaculosectorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCespectaculosectorid_Visible, edtavCespectaculosectorid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEspectaculosectornamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divEspectaculosectornamefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblespectaculosectornamefilter_Internalname, "Espectaculo Sector Name", "", "", lblLblespectaculosectornamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e121i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCespectaculosectorname_Internalname, "Espectaculo Sector Name", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCespectaculosectorname_Internalname, AV7cEspectaculoSectorName, StringUtil.RTrim( context.localUtil.Format( AV7cEspectaculoSectorName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCespectaculosectorname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCespectaculosectorname_Visible, edtavCespectaculosectorname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEspectaculosectorcantidadasientosfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEspectaculosectorcantidadasientosfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblespectaculosectorcantidadasientosfilter_Internalname, "Espectaculo Sector Cantidad Asientos", "", "", lblLblespectaculosectorcantidadasientosfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e131i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCespectaculosectorcantidadasientos_Internalname, "Espectaculo Sector Cantidad Asientos", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCespectaculosectorcantidadasientos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cEspectaculoSectorCantidadAsientos), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCespectaculosectorcantidadasientos_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cEspectaculoSectorCantidadAsientos), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cEspectaculoSectorCantidadAsientos), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCespectaculosectorcantidadasientos_Jsonclick, 0, "Attribute", "", "", "", "", edtavCespectaculosectorcantidadasientos_Visible, edtavCespectaculosectorcantidadasientos_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEspectaculosectorestadosectorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEspectaculosectorestadosectorfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblespectaculosectorestadosectorfilter_Internalname, "Espectaculo Sector Estado Sector", "", "", lblLblespectaculosectorestadosectorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e141i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCespectaculosectorestadosector_Internalname, "Espectaculo Sector Estado Sector", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCespectaculosectorestadosector_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cEspectaculoSectorEstadoSector), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCespectaculosectorestadosector_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cEspectaculoSectorEstadoSector), "ZZZ9") : context.localUtil.Format( (decimal)(AV9cEspectaculoSectorEstadoSector), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCespectaculosectorestadosector_Jsonclick, 0, "Attribute", "", "", "", "", edtavCespectaculosectorestadosector_Visible, edtavCespectaculosectorestadosector_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEspectaculosectorpreciofiltercontainer_Internalname, 1, 0, "px", 0, "px", divEspectaculosectorpreciofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblespectaculosectorpreciofilter_Internalname, "Espectaculo Sector Precio", "", "", lblLblespectaculosectorpreciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e151i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCespectaculosectorprecio_Internalname, "Espectaculo Sector Precio", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCespectaculosectorprecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cEspectaculoSectorPrecio), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCespectaculosectorprecio_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cEspectaculoSectorPrecio), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cEspectaculoSectorPrecio), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCespectaculosectorprecio_Jsonclick, 0, "Attribute", "", "", "", "", edtavCespectaculosectorprecio_Visible, edtavCespectaculosectorprecio_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e161i1_client"+"'", TempTags, "", 2, "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1I2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_10-161416", 0) ;
            }
            Form.Meta.addItem("description", "Selection List Sector", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1I0( ) ;
      }

      protected void WS1I2( )
      {
         START1I2( ) ;
         EVT1I2( ) ;
      }

      protected void EVT1I2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_64_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A31EspectaculoSectorId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoSectorId_Internalname), ",", "."));
                              A32EspectaculoSectorName = cgiGet( edtEspectaculoSectorName_Internalname);
                              A33EspectaculoSectorCantidadAsien = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoSectorCantidadAsien_Internalname), ",", "."));
                              A35EspectaculoSectorPrecio = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoSectorPrecio_Internalname), ",", "."));
                              A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E181I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cespectaculosectorid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOSECTORID"), ",", ".") != Convert.ToDecimal( AV6cEspectaculoSectorId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cespectaculosectorname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESPECTACULOSECTORNAME"), AV7cEspectaculoSectorName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cespectaculosectorcantidadasientos Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOSECTORCANTIDADASIENTOS"), ",", ".") != Convert.ToDecimal( AV8cEspectaculoSectorCantidadAsientos )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cespectaculosectorestadosector Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOSECTORESTADOSECTOR"), ",", ".") != Convert.ToDecimal( AV9cEspectaculoSectorEstadoSector )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cespectaculosectorprecio Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOSECTORPRECIO"), ",", ".") != Convert.ToDecimal( AV10cEspectaculoSectorPrecio )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E191I2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1I2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA1I2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cEspectaculoSectorId ,
                                        string AV7cEspectaculoSectorName ,
                                        short AV8cEspectaculoSectorCantidadAsientos ,
                                        short AV9cEspectaculoSectorEstadoSector ,
                                        short AV10cEspectaculoSectorPrecio ,
                                        short AV11pEspectaculoId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF1I2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ESPECTACULOSECTORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A31EspectaculoSectorId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOSECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoSectorId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF1I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cEspectaculoSectorName ,
                                                 AV8cEspectaculoSectorCantidadAsientos ,
                                                 AV9cEspectaculoSectorEstadoSector ,
                                                 AV10cEspectaculoSectorPrecio ,
                                                 A32EspectaculoSectorName ,
                                                 A33EspectaculoSectorCantidadAsien ,
                                                 A34EspectaculoSectorEstadoSector ,
                                                 A35EspectaculoSectorPrecio ,
                                                 AV11pEspectaculoId ,
                                                 AV6cEspectaculoSectorId ,
                                                 A1EspectaculoId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cEspectaculoSectorName = StringUtil.Concat( StringUtil.RTrim( AV7cEspectaculoSectorName), "%", "");
            /* Using cursor H001I2 */
            pr_default.execute(0, new Object[] {AV11pEspectaculoId, AV6cEspectaculoSectorId, lV7cEspectaculoSectorName, AV8cEspectaculoSectorCantidadAsientos, AV9cEspectaculoSectorEstadoSector, AV10cEspectaculoSectorPrecio, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A34EspectaculoSectorEstadoSector = H001I2_A34EspectaculoSectorEstadoSector[0];
               A1EspectaculoId = H001I2_A1EspectaculoId[0];
               A35EspectaculoSectorPrecio = H001I2_A35EspectaculoSectorPrecio[0];
               A33EspectaculoSectorCantidadAsien = H001I2_A33EspectaculoSectorCantidadAsien[0];
               A32EspectaculoSectorName = H001I2_A32EspectaculoSectorName[0];
               A31EspectaculoSectorId = H001I2_A31EspectaculoSectorId[0];
               /* Execute user event: Load */
               E181I2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB1I0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1I2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ESPECTACULOSECTORID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A31EspectaculoSectorId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cEspectaculoSectorName ,
                                              AV8cEspectaculoSectorCantidadAsientos ,
                                              AV9cEspectaculoSectorEstadoSector ,
                                              AV10cEspectaculoSectorPrecio ,
                                              A32EspectaculoSectorName ,
                                              A33EspectaculoSectorCantidadAsien ,
                                              A34EspectaculoSectorEstadoSector ,
                                              A35EspectaculoSectorPrecio ,
                                              AV11pEspectaculoId ,
                                              AV6cEspectaculoSectorId ,
                                              A1EspectaculoId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cEspectaculoSectorName = StringUtil.Concat( StringUtil.RTrim( AV7cEspectaculoSectorName), "%", "");
         /* Using cursor H001I3 */
         pr_default.execute(1, new Object[] {AV11pEspectaculoId, AV6cEspectaculoSectorId, lV7cEspectaculoSectorName, AV8cEspectaculoSectorCantidadAsientos, AV9cEspectaculoSectorEstadoSector, AV10cEspectaculoSectorPrecio});
         GRID1_nRecordCount = H001I3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoSectorId, AV7cEspectaculoSectorName, AV8cEspectaculoSectorCantidadAsientos, AV9cEspectaculoSectorEstadoSector, AV10cEspectaculoSectorPrecio, AV11pEspectaculoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoSectorId, AV7cEspectaculoSectorName, AV8cEspectaculoSectorCantidadAsientos, AV9cEspectaculoSectorEstadoSector, AV10cEspectaculoSectorPrecio, AV11pEspectaculoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoSectorId, AV7cEspectaculoSectorName, AV8cEspectaculoSectorCantidadAsientos, AV9cEspectaculoSectorEstadoSector, AV10cEspectaculoSectorPrecio, AV11pEspectaculoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoSectorId, AV7cEspectaculoSectorName, AV8cEspectaculoSectorCantidadAsientos, AV9cEspectaculoSectorEstadoSector, AV10cEspectaculoSectorPrecio, AV11pEspectaculoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEspectaculoSectorId, AV7cEspectaculoSectorName, AV8cEspectaculoSectorCantidadAsientos, AV9cEspectaculoSectorEstadoSector, AV10cEspectaculoSectorPrecio, AV11pEspectaculoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCespectaculosectorid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCespectaculosectorid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCESPECTACULOSECTORID");
               GX_FocusControl = edtavCespectaculosectorid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cEspectaculoSectorId = 0;
               AssignAttri("", false, "AV6cEspectaculoSectorId", StringUtil.LTrimStr( (decimal)(AV6cEspectaculoSectorId), 4, 0));
            }
            else
            {
               AV6cEspectaculoSectorId = (short)(context.localUtil.CToN( cgiGet( edtavCespectaculosectorid_Internalname), ",", "."));
               AssignAttri("", false, "AV6cEspectaculoSectorId", StringUtil.LTrimStr( (decimal)(AV6cEspectaculoSectorId), 4, 0));
            }
            AV7cEspectaculoSectorName = cgiGet( edtavCespectaculosectorname_Internalname);
            AssignAttri("", false, "AV7cEspectaculoSectorName", AV7cEspectaculoSectorName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCespectaculosectorcantidadasientos_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCespectaculosectorcantidadasientos_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCESPECTACULOSECTORCANTIDADASIENTOS");
               GX_FocusControl = edtavCespectaculosectorcantidadasientos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cEspectaculoSectorCantidadAsientos = 0;
               AssignAttri("", false, "AV8cEspectaculoSectorCantidadAsientos", StringUtil.LTrimStr( (decimal)(AV8cEspectaculoSectorCantidadAsientos), 4, 0));
            }
            else
            {
               AV8cEspectaculoSectorCantidadAsientos = (short)(context.localUtil.CToN( cgiGet( edtavCespectaculosectorcantidadasientos_Internalname), ",", "."));
               AssignAttri("", false, "AV8cEspectaculoSectorCantidadAsientos", StringUtil.LTrimStr( (decimal)(AV8cEspectaculoSectorCantidadAsientos), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCespectaculosectorestadosector_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCespectaculosectorestadosector_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCESPECTACULOSECTORESTADOSECTOR");
               GX_FocusControl = edtavCespectaculosectorestadosector_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cEspectaculoSectorEstadoSector = 0;
               AssignAttri("", false, "AV9cEspectaculoSectorEstadoSector", StringUtil.LTrimStr( (decimal)(AV9cEspectaculoSectorEstadoSector), 4, 0));
            }
            else
            {
               AV9cEspectaculoSectorEstadoSector = (short)(context.localUtil.CToN( cgiGet( edtavCespectaculosectorestadosector_Internalname), ",", "."));
               AssignAttri("", false, "AV9cEspectaculoSectorEstadoSector", StringUtil.LTrimStr( (decimal)(AV9cEspectaculoSectorEstadoSector), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCespectaculosectorprecio_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCespectaculosectorprecio_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCESPECTACULOSECTORPRECIO");
               GX_FocusControl = edtavCespectaculosectorprecio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cEspectaculoSectorPrecio = 0;
               AssignAttri("", false, "AV10cEspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(AV10cEspectaculoSectorPrecio), 4, 0));
            }
            else
            {
               AV10cEspectaculoSectorPrecio = (short)(context.localUtil.CToN( cgiGet( edtavCespectaculosectorprecio_Internalname), ",", "."));
               AssignAttri("", false, "AV10cEspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(AV10cEspectaculoSectorPrecio), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOSECTORID"), ",", ".") != Convert.ToDecimal( AV6cEspectaculoSectorId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESPECTACULOSECTORNAME"), AV7cEspectaculoSectorName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOSECTORCANTIDADASIENTOS"), ",", ".") != Convert.ToDecimal( AV8cEspectaculoSectorCantidadAsientos )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOSECTORESTADOSECTOR"), ",", ".") != Convert.ToDecimal( AV9cEspectaculoSectorEstadoSector )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESPECTACULOSECTORPRECIO"), ",", ".") != Convert.ToDecimal( AV10cEspectaculoSectorPrecio )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E171I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171I2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Sector", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E181I2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV16Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            context.DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E191I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E191I2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pEspectaculoSectorId = A31EspectaculoSectorId;
         AssignAttri("", false, "AV12pEspectaculoSectorId", StringUtil.LTrimStr( (decimal)(AV12pEspectaculoSectorId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV12pEspectaculoSectorId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pEspectaculoSectorId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11pEspectaculoId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV11pEspectaculoId", StringUtil.LTrimStr( (decimal)(AV11pEspectaculoId), 4, 0));
         AV12pEspectaculoSectorId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV12pEspectaculoSectorId", StringUtil.LTrimStr( (decimal)(AV12pEspectaculoSectorId), 4, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA1I2( ) ;
         WS1I2( ) ;
         WE1I2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022882235775", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gx00c1.js", "?2022882235775", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtEspectaculoSectorId_Internalname = "ESPECTACULOSECTORID_"+sGXsfl_64_idx;
         edtEspectaculoSectorName_Internalname = "ESPECTACULOSECTORNAME_"+sGXsfl_64_idx;
         edtEspectaculoSectorCantidadAsien_Internalname = "ESPECTACULOSECTORCANTIDADASIEN_"+sGXsfl_64_idx;
         edtEspectaculoSectorPrecio_Internalname = "ESPECTACULOSECTORPRECIO_"+sGXsfl_64_idx;
         edtEspectaculoId_Internalname = "ESPECTACULOID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtEspectaculoSectorId_Internalname = "ESPECTACULOSECTORID_"+sGXsfl_64_fel_idx;
         edtEspectaculoSectorName_Internalname = "ESPECTACULOSECTORNAME_"+sGXsfl_64_fel_idx;
         edtEspectaculoSectorCantidadAsien_Internalname = "ESPECTACULOSECTORCANTIDADASIEN_"+sGXsfl_64_fel_idx;
         edtEspectaculoSectorPrecio_Internalname = "ESPECTACULOSECTORPRECIO_"+sGXsfl_64_fel_idx;
         edtEspectaculoId_Internalname = "ESPECTACULOID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         SubsflControlProps_642( ) ;
         WB1I0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoSectorId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV16Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoSectorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoSectorId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A31EspectaculoSectorId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEspectaculoSectorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtEspectaculoSectorName_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoSectorId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtEspectaculoSectorName_Internalname, "Link", edtEspectaculoSectorName_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoSectorName_Internalname,(string)A32EspectaculoSectorName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtEspectaculoSectorName_Link,(string)"",(string)"",(string)"",(string)edtEspectaculoSectorName_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoSectorCantidadAsien_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A33EspectaculoSectorCantidadAsien), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A33EspectaculoSectorCantidadAsien), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEspectaculoSectorCantidadAsien_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoSectorPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A35EspectaculoSectorPrecio), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A35EspectaculoSectorPrecio), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEspectaculoSectorPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEspectaculoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes1I2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl64( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sector Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sector Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cantidad Asientos") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sector Precio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Espectaculo Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoSectorId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", A32EspectaculoSectorName);
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtEspectaculoSectorName_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33EspectaculoSectorCantidadAsien), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A35EspectaculoSectorPrecio), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblespectaculosectoridfilter_Internalname = "LBLESPECTACULOSECTORIDFILTER";
         edtavCespectaculosectorid_Internalname = "vCESPECTACULOSECTORID";
         divEspectaculosectoridfiltercontainer_Internalname = "ESPECTACULOSECTORIDFILTERCONTAINER";
         lblLblespectaculosectornamefilter_Internalname = "LBLESPECTACULOSECTORNAMEFILTER";
         edtavCespectaculosectorname_Internalname = "vCESPECTACULOSECTORNAME";
         divEspectaculosectornamefiltercontainer_Internalname = "ESPECTACULOSECTORNAMEFILTERCONTAINER";
         lblLblespectaculosectorcantidadasientosfilter_Internalname = "LBLESPECTACULOSECTORCANTIDADASIENTOSFILTER";
         edtavCespectaculosectorcantidadasientos_Internalname = "vCESPECTACULOSECTORCANTIDADASIENTOS";
         divEspectaculosectorcantidadasientosfiltercontainer_Internalname = "ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER";
         lblLblespectaculosectorestadosectorfilter_Internalname = "LBLESPECTACULOSECTORESTADOSECTORFILTER";
         edtavCespectaculosectorestadosector_Internalname = "vCESPECTACULOSECTORESTADOSECTOR";
         divEspectaculosectorestadosectorfiltercontainer_Internalname = "ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER";
         lblLblespectaculosectorpreciofilter_Internalname = "LBLESPECTACULOSECTORPRECIOFILTER";
         edtavCespectaculosectorprecio_Internalname = "vCESPECTACULOSECTORPRECIO";
         divEspectaculosectorpreciofiltercontainer_Internalname = "ESPECTACULOSECTORPRECIOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtEspectaculoSectorId_Internalname = "ESPECTACULOSECTORID";
         edtEspectaculoSectorName_Internalname = "ESPECTACULOSECTORNAME";
         edtEspectaculoSectorCantidadAsien_Internalname = "ESPECTACULOSECTORCANTIDADASIEN";
         edtEspectaculoSectorPrecio_Internalname = "ESPECTACULOSECTORPRECIO";
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoSectorPrecio_Jsonclick = "";
         edtEspectaculoSectorCantidadAsien_Jsonclick = "";
         edtEspectaculoSectorName_Jsonclick = "";
         edtEspectaculoSectorName_Link = "";
         edtEspectaculoSectorId_Jsonclick = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCespectaculosectorprecio_Jsonclick = "";
         edtavCespectaculosectorprecio_Enabled = 1;
         edtavCespectaculosectorprecio_Visible = 1;
         edtavCespectaculosectorestadosector_Jsonclick = "";
         edtavCespectaculosectorestadosector_Enabled = 1;
         edtavCespectaculosectorestadosector_Visible = 1;
         edtavCespectaculosectorcantidadasientos_Jsonclick = "";
         edtavCespectaculosectorcantidadasientos_Enabled = 1;
         edtavCespectaculosectorcantidadasientos_Visible = 1;
         edtavCespectaculosectorname_Jsonclick = "";
         edtavCespectaculosectorname_Enabled = 1;
         edtavCespectaculosectorname_Visible = 1;
         edtavCespectaculosectorid_Jsonclick = "";
         edtavCespectaculosectorid_Enabled = 1;
         edtavCespectaculosectorid_Visible = 1;
         divEspectaculosectorpreciofiltercontainer_Class = "AdvancedContainerItem";
         divEspectaculosectorestadosectorfiltercontainer_Class = "AdvancedContainerItem";
         divEspectaculosectorcantidadasientosfiltercontainer_Class = "AdvancedContainerItem";
         divEspectaculosectornamefiltercontainer_Class = "AdvancedContainerItem";
         divEspectaculosectoridfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Sector";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEspectaculoSectorId',fld:'vCESPECTACULOSECTORID',pic:'ZZZ9'},{av:'AV7cEspectaculoSectorName',fld:'vCESPECTACULOSECTORNAME',pic:''},{av:'AV8cEspectaculoSectorCantidadAsientos',fld:'vCESPECTACULOSECTORCANTIDADASIENTOS',pic:'ZZZ9'},{av:'AV9cEspectaculoSectorEstadoSector',fld:'vCESPECTACULOSECTORESTADOSECTOR',pic:'ZZZ9'},{av:'AV10cEspectaculoSectorPrecio',fld:'vCESPECTACULOSECTORPRECIO',pic:'ZZZ9'},{av:'AV11pEspectaculoId',fld:'vPESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E161I1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLESPECTACULOSECTORIDFILTER.CLICK","{handler:'E111I1',iparms:[{av:'divEspectaculosectoridfiltercontainer_Class',ctrl:'ESPECTACULOSECTORIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESPECTACULOSECTORIDFILTER.CLICK",",oparms:[{av:'divEspectaculosectoridfiltercontainer_Class',ctrl:'ESPECTACULOSECTORIDFILTERCONTAINER',prop:'Class'},{av:'edtavCespectaculosectorid_Visible',ctrl:'vCESPECTACULOSECTORID',prop:'Visible'}]}");
         setEventMetadata("LBLESPECTACULOSECTORNAMEFILTER.CLICK","{handler:'E121I1',iparms:[{av:'divEspectaculosectornamefiltercontainer_Class',ctrl:'ESPECTACULOSECTORNAMEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESPECTACULOSECTORNAMEFILTER.CLICK",",oparms:[{av:'divEspectaculosectornamefiltercontainer_Class',ctrl:'ESPECTACULOSECTORNAMEFILTERCONTAINER',prop:'Class'},{av:'edtavCespectaculosectorname_Visible',ctrl:'vCESPECTACULOSECTORNAME',prop:'Visible'}]}");
         setEventMetadata("LBLESPECTACULOSECTORCANTIDADASIENTOSFILTER.CLICK","{handler:'E131I1',iparms:[{av:'divEspectaculosectorcantidadasientosfiltercontainer_Class',ctrl:'ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESPECTACULOSECTORCANTIDADASIENTOSFILTER.CLICK",",oparms:[{av:'divEspectaculosectorcantidadasientosfiltercontainer_Class',ctrl:'ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER',prop:'Class'},{av:'edtavCespectaculosectorcantidadasientos_Visible',ctrl:'vCESPECTACULOSECTORCANTIDADASIENTOS',prop:'Visible'}]}");
         setEventMetadata("LBLESPECTACULOSECTORESTADOSECTORFILTER.CLICK","{handler:'E141I1',iparms:[{av:'divEspectaculosectorestadosectorfiltercontainer_Class',ctrl:'ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESPECTACULOSECTORESTADOSECTORFILTER.CLICK",",oparms:[{av:'divEspectaculosectorestadosectorfiltercontainer_Class',ctrl:'ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER',prop:'Class'},{av:'edtavCespectaculosectorestadosector_Visible',ctrl:'vCESPECTACULOSECTORESTADOSECTOR',prop:'Visible'}]}");
         setEventMetadata("LBLESPECTACULOSECTORPRECIOFILTER.CLICK","{handler:'E151I1',iparms:[{av:'divEspectaculosectorpreciofiltercontainer_Class',ctrl:'ESPECTACULOSECTORPRECIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESPECTACULOSECTORPRECIOFILTER.CLICK",",oparms:[{av:'divEspectaculosectorpreciofiltercontainer_Class',ctrl:'ESPECTACULOSECTORPRECIOFILTERCONTAINER',prop:'Class'},{av:'edtavCespectaculosectorprecio_Visible',ctrl:'vCESPECTACULOSECTORPRECIO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E191I2',iparms:[{av:'A31EspectaculoSectorId',fld:'ESPECTACULOSECTORID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pEspectaculoSectorId',fld:'vPESPECTACULOSECTORID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEspectaculoSectorId',fld:'vCESPECTACULOSECTORID',pic:'ZZZ9'},{av:'AV7cEspectaculoSectorName',fld:'vCESPECTACULOSECTORNAME',pic:''},{av:'AV8cEspectaculoSectorCantidadAsientos',fld:'vCESPECTACULOSECTORCANTIDADASIENTOS',pic:'ZZZ9'},{av:'AV9cEspectaculoSectorEstadoSector',fld:'vCESPECTACULOSECTORESTADOSECTOR',pic:'ZZZ9'},{av:'AV10cEspectaculoSectorPrecio',fld:'vCESPECTACULOSECTORPRECIO',pic:'ZZZ9'},{av:'AV11pEspectaculoId',fld:'vPESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEspectaculoSectorId',fld:'vCESPECTACULOSECTORID',pic:'ZZZ9'},{av:'AV7cEspectaculoSectorName',fld:'vCESPECTACULOSECTORNAME',pic:''},{av:'AV8cEspectaculoSectorCantidadAsientos',fld:'vCESPECTACULOSECTORCANTIDADASIENTOS',pic:'ZZZ9'},{av:'AV9cEspectaculoSectorEstadoSector',fld:'vCESPECTACULOSECTORESTADOSECTOR',pic:'ZZZ9'},{av:'AV10cEspectaculoSectorPrecio',fld:'vCESPECTACULOSECTORPRECIO',pic:'ZZZ9'},{av:'AV11pEspectaculoId',fld:'vPESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEspectaculoSectorId',fld:'vCESPECTACULOSECTORID',pic:'ZZZ9'},{av:'AV7cEspectaculoSectorName',fld:'vCESPECTACULOSECTORNAME',pic:''},{av:'AV8cEspectaculoSectorCantidadAsientos',fld:'vCESPECTACULOSECTORCANTIDADASIENTOS',pic:'ZZZ9'},{av:'AV9cEspectaculoSectorEstadoSector',fld:'vCESPECTACULOSECTORESTADOSECTOR',pic:'ZZZ9'},{av:'AV10cEspectaculoSectorPrecio',fld:'vCESPECTACULOSECTORPRECIO',pic:'ZZZ9'},{av:'AV11pEspectaculoId',fld:'vPESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEspectaculoSectorId',fld:'vCESPECTACULOSECTORID',pic:'ZZZ9'},{av:'AV7cEspectaculoSectorName',fld:'vCESPECTACULOSECTORNAME',pic:''},{av:'AV8cEspectaculoSectorCantidadAsientos',fld:'vCESPECTACULOSECTORCANTIDADASIENTOS',pic:'ZZZ9'},{av:'AV9cEspectaculoSectorEstadoSector',fld:'vCESPECTACULOSECTORESTADOSECTOR',pic:'ZZZ9'},{av:'AV10cEspectaculoSectorPrecio',fld:'vCESPECTACULOSECTORPRECIO',pic:'ZZZ9'},{av:'AV11pEspectaculoId',fld:'vPESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Espectaculoid',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7cEspectaculoSectorName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblespectaculosectoridfilter_Jsonclick = "";
         TempTags = "";
         lblLblespectaculosectornamefilter_Jsonclick = "";
         lblLblespectaculosectorcantidadasientosfilter_Jsonclick = "";
         lblLblespectaculosectorestadosectorfilter_Jsonclick = "";
         lblLblespectaculosectorpreciofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV16Linkselection_GXI = "";
         A32EspectaculoSectorName = "";
         scmdbuf = "";
         lV7cEspectaculoSectorName = "";
         H001I2_A34EspectaculoSectorEstadoSector = new short[1] ;
         H001I2_A1EspectaculoId = new short[1] ;
         H001I2_A35EspectaculoSectorPrecio = new short[1] ;
         H001I2_A33EspectaculoSectorCantidadAsien = new short[1] ;
         H001I2_A32EspectaculoSectorName = new string[] {""} ;
         H001I2_A31EspectaculoSectorId = new short[1] ;
         H001I3_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00c1__default(),
            new Object[][] {
                new Object[] {
               H001I2_A34EspectaculoSectorEstadoSector, H001I2_A1EspectaculoId, H001I2_A35EspectaculoSectorPrecio, H001I2_A33EspectaculoSectorCantidadAsien, H001I2_A32EspectaculoSectorName, H001I2_A31EspectaculoSectorId
               }
               , new Object[] {
               H001I3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11pEspectaculoId ;
      private short AV12pEspectaculoSectorId ;
      private short wcpOAV11pEspectaculoId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cEspectaculoSectorId ;
      private short AV8cEspectaculoSectorCantidadAsientos ;
      private short AV9cEspectaculoSectorEstadoSector ;
      private short AV10cEspectaculoSectorPrecio ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A31EspectaculoSectorId ;
      private short A33EspectaculoSectorCantidadAsien ;
      private short A35EspectaculoSectorPrecio ;
      private short A1EspectaculoId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A34EspectaculoSectorEstadoSector ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int edtavCespectaculosectorid_Enabled ;
      private int edtavCespectaculosectorid_Visible ;
      private int edtavCespectaculosectorname_Visible ;
      private int edtavCespectaculosectorname_Enabled ;
      private int edtavCespectaculosectorcantidadasientos_Enabled ;
      private int edtavCespectaculosectorcantidadasientos_Visible ;
      private int edtavCespectaculosectorestadosector_Enabled ;
      private int edtavCespectaculosectorestadosector_Visible ;
      private int edtavCespectaculosectorprecio_Enabled ;
      private int edtavCespectaculosectorprecio_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divEspectaculosectoridfiltercontainer_Class ;
      private string divEspectaculosectornamefiltercontainer_Class ;
      private string divEspectaculosectorcantidadasientosfiltercontainer_Class ;
      private string divEspectaculosectorestadosectorfiltercontainer_Class ;
      private string divEspectaculosectorpreciofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divEspectaculosectoridfiltercontainer_Internalname ;
      private string lblLblespectaculosectoridfilter_Internalname ;
      private string lblLblespectaculosectoridfilter_Jsonclick ;
      private string edtavCespectaculosectorid_Internalname ;
      private string TempTags ;
      private string edtavCespectaculosectorid_Jsonclick ;
      private string divEspectaculosectornamefiltercontainer_Internalname ;
      private string lblLblespectaculosectornamefilter_Internalname ;
      private string lblLblespectaculosectornamefilter_Jsonclick ;
      private string edtavCespectaculosectorname_Internalname ;
      private string edtavCespectaculosectorname_Jsonclick ;
      private string divEspectaculosectorcantidadasientosfiltercontainer_Internalname ;
      private string lblLblespectaculosectorcantidadasientosfilter_Internalname ;
      private string lblLblespectaculosectorcantidadasientosfilter_Jsonclick ;
      private string edtavCespectaculosectorcantidadasientos_Internalname ;
      private string edtavCespectaculosectorcantidadasientos_Jsonclick ;
      private string divEspectaculosectorestadosectorfiltercontainer_Internalname ;
      private string lblLblespectaculosectorestadosectorfilter_Internalname ;
      private string lblLblespectaculosectorestadosectorfilter_Jsonclick ;
      private string edtavCespectaculosectorestadosector_Internalname ;
      private string edtavCespectaculosectorestadosector_Jsonclick ;
      private string divEspectaculosectorpreciofiltercontainer_Internalname ;
      private string lblLblespectaculosectorpreciofilter_Internalname ;
      private string lblLblespectaculosectorpreciofilter_Jsonclick ;
      private string edtavCespectaculosectorprecio_Internalname ;
      private string edtavCespectaculosectorprecio_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtEspectaculoSectorId_Internalname ;
      private string edtEspectaculoSectorName_Internalname ;
      private string edtEspectaculoSectorCantidadAsien_Internalname ;
      private string edtEspectaculoSectorPrecio_Internalname ;
      private string edtEspectaculoId_Internalname ;
      private string scmdbuf ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtEspectaculoSectorId_Jsonclick ;
      private string edtEspectaculoSectorName_Link ;
      private string edtEspectaculoSectorName_Jsonclick ;
      private string edtEspectaculoSectorCantidadAsien_Jsonclick ;
      private string edtEspectaculoSectorPrecio_Jsonclick ;
      private string edtEspectaculoId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cEspectaculoSectorName ;
      private string AV16Linkselection_GXI ;
      private string A32EspectaculoSectorName ;
      private string lV7cEspectaculoSectorName ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H001I2_A34EspectaculoSectorEstadoSector ;
      private short[] H001I2_A1EspectaculoId ;
      private short[] H001I2_A35EspectaculoSectorPrecio ;
      private short[] H001I2_A33EspectaculoSectorCantidadAsien ;
      private string[] H001I2_A32EspectaculoSectorName ;
      private short[] H001I2_A31EspectaculoSectorId ;
      private long[] H001I3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP1_pEspectaculoSectorId ;
      private GXWebForm Form ;
   }

   public class gx00c1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001I2( IGxContext context ,
                                             string AV7cEspectaculoSectorName ,
                                             short AV8cEspectaculoSectorCantidadAsientos ,
                                             short AV9cEspectaculoSectorEstadoSector ,
                                             short AV10cEspectaculoSectorPrecio ,
                                             string A32EspectaculoSectorName ,
                                             short A33EspectaculoSectorCantidadAsien ,
                                             short A34EspectaculoSectorEstadoSector ,
                                             short A35EspectaculoSectorPrecio ,
                                             short AV11pEspectaculoId ,
                                             short AV6cEspectaculoSectorId ,
                                             short A1EspectaculoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [EspectaculoSectorEstadoSector], [EspectaculoId], [EspectaculoSectorPrecio], [EspectaculoSectorCantidadAsien], [EspectaculoSectorName], [EspectaculoSectorId]";
         sFromString = " FROM [EspectaculoSector]";
         sOrderString = "";
         AddWhere(sWhereString, "([EspectaculoId] = @AV11pEspectaculoId and [EspectaculoSectorId] >= @AV6cEspectaculoSectorId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cEspectaculoSectorName)) )
         {
            AddWhere(sWhereString, "([EspectaculoSectorName] like @lV7cEspectaculoSectorName)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV8cEspectaculoSectorCantidadAsientos) )
         {
            AddWhere(sWhereString, "([EspectaculoSectorCantidadAsien] >= @AV8cEspectaculoSectorCantidadAsientos)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV9cEspectaculoSectorEstadoSector) )
         {
            AddWhere(sWhereString, "([EspectaculoSectorEstadoSector] >= @AV9cEspectaculoSectorEstadoSector)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV10cEspectaculoSectorPrecio) )
         {
            AddWhere(sWhereString, "([EspectaculoSectorPrecio] >= @AV10cEspectaculoSectorPrecio)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [EspectaculoId], [EspectaculoSectorId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H001I3( IGxContext context ,
                                             string AV7cEspectaculoSectorName ,
                                             short AV8cEspectaculoSectorCantidadAsientos ,
                                             short AV9cEspectaculoSectorEstadoSector ,
                                             short AV10cEspectaculoSectorPrecio ,
                                             string A32EspectaculoSectorName ,
                                             short A33EspectaculoSectorCantidadAsien ,
                                             short A34EspectaculoSectorEstadoSector ,
                                             short A35EspectaculoSectorPrecio ,
                                             short AV11pEspectaculoId ,
                                             short AV6cEspectaculoSectorId ,
                                             short A1EspectaculoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [EspectaculoSector]";
         AddWhere(sWhereString, "([EspectaculoId] = @AV11pEspectaculoId and [EspectaculoSectorId] >= @AV6cEspectaculoSectorId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cEspectaculoSectorName)) )
         {
            AddWhere(sWhereString, "([EspectaculoSectorName] like @lV7cEspectaculoSectorName)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV8cEspectaculoSectorCantidadAsientos) )
         {
            AddWhere(sWhereString, "([EspectaculoSectorCantidadAsien] >= @AV8cEspectaculoSectorCantidadAsientos)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV9cEspectaculoSectorEstadoSector) )
         {
            AddWhere(sWhereString, "([EspectaculoSectorEstadoSector] >= @AV9cEspectaculoSectorEstadoSector)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV10cEspectaculoSectorPrecio) )
         {
            AddWhere(sWhereString, "([EspectaculoSectorPrecio] >= @AV10cEspectaculoSectorPrecio)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001I2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H001I3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH001I2;
          prmH001I2 = new Object[] {
          new ParDef("@AV11pEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@AV6cEspectaculoSectorId",GXType.Int16,4,0) ,
          new ParDef("@lV7cEspectaculoSectorName",GXType.NVarChar,40,0) ,
          new ParDef("@AV8cEspectaculoSectorCantidadAsientos",GXType.Int16,4,0) ,
          new ParDef("@AV9cEspectaculoSectorEstadoSector",GXType.Int16,4,0) ,
          new ParDef("@AV10cEspectaculoSectorPrecio",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001I3;
          prmH001I3 = new Object[] {
          new ParDef("@AV11pEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@AV6cEspectaculoSectorId",GXType.Int16,4,0) ,
          new ParDef("@lV7cEspectaculoSectorName",GXType.NVarChar,40,0) ,
          new ParDef("@AV8cEspectaculoSectorCantidadAsientos",GXType.Int16,4,0) ,
          new ParDef("@AV9cEspectaculoSectorEstadoSector",GXType.Int16,4,0) ,
          new ParDef("@AV10cEspectaculoSectorPrecio",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001I2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H001I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001I3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
