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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class entradageneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public entradageneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
      }

      public entradageneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_EntradaId )
      {
         this.A23EntradaId = aP0_EntradaId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "EntradaId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A23EntradaId = (short)(NumberUtil.Val( GetPar( "EntradaId"), "."));
                  AssignAttri(sPrefix, false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A23EntradaId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "EntradaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "EntradaId");
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
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0N2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "EntradaGeneral";
               context.Gx_err = 0;
               WS0N2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Entrada General") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 511400), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 511400), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 511400), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281118495560", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 511400), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 511400), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 511400), false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("entradageneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A23EntradaId,4,0))}, new string[] {"EntradaId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EntradaGeneral");
         forbiddenHiddens.Add("ClienteId", context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9"));
         forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("entradageneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA23EntradaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA23EntradaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"LUGARSECTORCANTIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"LUGARSECTORVENDIDAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm0N2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "EntradaGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Entrada General" ;
      }

      protected void WB0N0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "entradageneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewActionsCell", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group WWViewActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modificar", bttBtnupdate_Jsonclick, 7, "Modificar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110n1_client"+"'", TempTags, "", 2, "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 7, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120n1_client"+"'", TempTags, "", 2, "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEntradaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEntradaId_Internalname, "Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEntradaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23EntradaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEntradaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A23EntradaId), "ZZZ9") : context.localUtil.Format( (decimal)(A23EntradaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntradaId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEntradaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEntradaFecha_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEntradaFecha_Internalname, "Fecha", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtEntradaFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtEntradaFecha_Internalname, context.localUtil.Format(A42EntradaFecha, "99/99/99"), context.localUtil.Format( A42EntradaFecha, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntradaFecha_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEntradaFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_bitmap( context, edtEntradaFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEntradaFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EntradaGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Cliente Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteId), 4, 0, ",", "")), StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9") : context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClienteName_Internalname, "Cliente Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteName_Internalname, A10ClienteName, StringUtil.RTrim( context.localUtil.Format( A10ClienteName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtClienteName_Link, "", "", "", edtClienteName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoId_Internalname, "Espectaculo Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoName_Internalname, "Espectaculo Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoName_Internalname, A2EspectaculoName, StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtEspectaculoName_Link, "", "", "", edtEspectaculoName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoFecha_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoFecha_Internalname, "Espectaculo Fecha", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtEspectaculoFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtEspectaculoFecha_Internalname, context.localUtil.Format(A16EspectaculoFecha, "99/99/99"), context.localUtil.Format( A16EspectaculoFecha, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFecha_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_bitmap( context, edtEspectaculoFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEspectaculoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EntradaGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPaisName_Internalname, "Pais Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPaisName_Internalname, A6PaisName, StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtPaisName_Link, "", "", "", edtPaisName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaisName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLugarName_Internalname, "Lugar Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtLugarName_Internalname, A5LugarName, StringUtil.RTrim( context.localUtil.Format( A5LugarName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtLugarName_Link, "", "", "", edtLugarName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtLugarName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarSectorId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLugarSectorId_Internalname, "Lugar Sector Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtLugarSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", "")), StringUtil.LTrim( ((edtLugarSectorId_Enabled!=0) ? context.localUtil.Format( (decimal)(A27LugarSectorId), "ZZZ9") : context.localUtil.Format( (decimal)(A27LugarSectorId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarSectorId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtLugarSectorId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarSectorDisponibles_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLugarSectorDisponibles_Internalname, "Lugar Sector Disponibles", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtLugarSectorDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ",", "")), StringUtil.LTrim( ((edtLugarSectorDisponibles_Enabled!=0) ? context.localUtil.Format( (decimal)(A38LugarSectorDisponibles), "ZZZ9") : context.localUtil.Format( (decimal)(A38LugarSectorDisponibles), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarSectorDisponibles_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtLugarSectorDisponibles_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipoEspectaculoName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTipoEspectaculoName_Internalname, "Tipo Espectaculo Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoName_Internalname, A8TipoEspectaculoName, StringUtil.RTrim( context.localUtil.Format( A8TipoEspectaculoName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtTipoEspectaculoName_Link, "", "", "", edtTipoEspectaculoName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtTipoEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoFuncionId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoFuncionId_Internalname, "Espectaculo Funcion Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoFuncionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A47EspectaculoFuncionId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoFuncionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A47EspectaculoFuncionId), "ZZZ9") : context.localUtil.Format( (decimal)(A47EspectaculoFuncionId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFuncionId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoFuncionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoFuncionName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoFuncionName_Internalname, "Espectaculo Funcion Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoFuncionName_Internalname, A48EspectaculoFuncionName, StringUtil.RTrim( context.localUtil.Format( A48EspectaculoFuncionName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFuncionName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoFuncionName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPaisId_Internalname, "Pais Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPaisId_Enabled!=0) ? context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9") : context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaisId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoPaisName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoPaisName_Internalname, "Pais Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoPaisName_Internalname, A50EspectaculoPaisName, StringUtil.RTrim( context.localUtil.Format( A50EspectaculoPaisName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoPaisName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoPaisName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarSectorName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLugarSectorName_Internalname, "Lugar Sector Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtLugarSectorName_Internalname, A28LugarSectorName, StringUtil.RTrim( context.localUtil.Format( A28LugarSectorName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarSectorName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtLugarSectorName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarSectorPrecio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLugarSectorPrecio_Internalname, "Lugar Sector Precio", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtLugarSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ",", "")), StringUtil.LTrim( ((edtLugarSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9") : context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarSectorPrecio_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtLugarSectorPrecio_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImagestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Espectaculo Imagen", "col-sm-3 ReadonlyAttributeLabel ReadonlyResponsiveImageAttributeLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
            StyleString = "";
            A26EspectaculoImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000EspectaculoImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.PathToRelativeUrl( A26EspectaculoImagen));
            GxWebStd.gx_bitmap( context, imgEspectaculoImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A26EspectaculoImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_EntradaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0N2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_10-162473", 0) ;
               }
               Form.Meta.addItem("description", "Entrada General", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0N0( ) ;
            }
         }
      }

      protected void WS0N2( )
      {
         START0N2( ) ;
         EVT0N2( ) ;
      }

      protected void EVT0N2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0N2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0N2( ) ;
            }
         }
      }

      protected void PA0N2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         RF0N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "EntradaGeneral";
         context.Gx_err = 0;
      }

      protected void RF0N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000N3 */
            pr_default.execute(0, new Object[] {A23EntradaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A4LugarId = H000N3_A4LugarId[0];
               A7TipoEspectaculoId = H000N3_A7TipoEspectaculoId[0];
               A40000EspectaculoImagen_GXI = H000N3_A40000EspectaculoImagen_GXI[0];
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
               A30LugarSectorPrecio = H000N3_A30LugarSectorPrecio[0];
               AssignAttri(sPrefix, false, "A30LugarSectorPrecio", StringUtil.LTrimStr( (decimal)(A30LugarSectorPrecio), 4, 0));
               A28LugarSectorName = H000N3_A28LugarSectorName[0];
               AssignAttri(sPrefix, false, "A28LugarSectorName", A28LugarSectorName);
               A50EspectaculoPaisName = H000N3_A50EspectaculoPaisName[0];
               AssignAttri(sPrefix, false, "A50EspectaculoPaisName", A50EspectaculoPaisName);
               A3PaisId = H000N3_A3PaisId[0];
               AssignAttri(sPrefix, false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
               A48EspectaculoFuncionName = H000N3_A48EspectaculoFuncionName[0];
               AssignAttri(sPrefix, false, "A48EspectaculoFuncionName", A48EspectaculoFuncionName);
               A47EspectaculoFuncionId = H000N3_A47EspectaculoFuncionId[0];
               AssignAttri(sPrefix, false, "A47EspectaculoFuncionId", StringUtil.LTrimStr( (decimal)(A47EspectaculoFuncionId), 4, 0));
               A8TipoEspectaculoName = H000N3_A8TipoEspectaculoName[0];
               AssignAttri(sPrefix, false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
               A27LugarSectorId = H000N3_A27LugarSectorId[0];
               n27LugarSectorId = H000N3_n27LugarSectorId[0];
               AssignAttri(sPrefix, false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
               A5LugarName = H000N3_A5LugarName[0];
               AssignAttri(sPrefix, false, "A5LugarName", A5LugarName);
               A6PaisName = H000N3_A6PaisName[0];
               AssignAttri(sPrefix, false, "A6PaisName", A6PaisName);
               A16EspectaculoFecha = H000N3_A16EspectaculoFecha[0];
               AssignAttri(sPrefix, false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
               A2EspectaculoName = H000N3_A2EspectaculoName[0];
               AssignAttri(sPrefix, false, "A2EspectaculoName", A2EspectaculoName);
               A1EspectaculoId = H000N3_A1EspectaculoId[0];
               n1EspectaculoId = H000N3_n1EspectaculoId[0];
               AssignAttri(sPrefix, false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               A10ClienteName = H000N3_A10ClienteName[0];
               AssignAttri(sPrefix, false, "A10ClienteName", A10ClienteName);
               A9ClienteId = H000N3_A9ClienteId[0];
               AssignAttri(sPrefix, false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
               A42EntradaFecha = H000N3_A42EntradaFecha[0];
               AssignAttri(sPrefix, false, "A42EntradaFecha", context.localUtil.Format(A42EntradaFecha, "99/99/99"));
               A29LugarSectorCantidad = H000N3_A29LugarSectorCantidad[0];
               A37LugarSectorVendidas = H000N3_A37LugarSectorVendidas[0];
               n37LugarSectorVendidas = H000N3_n37LugarSectorVendidas[0];
               A26EspectaculoImagen = H000N3_A26EspectaculoImagen[0];
               AssignAttri(sPrefix, false, "A26EspectaculoImagen", A26EspectaculoImagen);
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
               A4LugarId = H000N3_A4LugarId[0];
               A7TipoEspectaculoId = H000N3_A7TipoEspectaculoId[0];
               A40000EspectaculoImagen_GXI = H000N3_A40000EspectaculoImagen_GXI[0];
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
               A16EspectaculoFecha = H000N3_A16EspectaculoFecha[0];
               AssignAttri(sPrefix, false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
               A2EspectaculoName = H000N3_A2EspectaculoName[0];
               AssignAttri(sPrefix, false, "A2EspectaculoName", A2EspectaculoName);
               A26EspectaculoImagen = H000N3_A26EspectaculoImagen[0];
               AssignAttri(sPrefix, false, "A26EspectaculoImagen", A26EspectaculoImagen);
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
               A5LugarName = H000N3_A5LugarName[0];
               AssignAttri(sPrefix, false, "A5LugarName", A5LugarName);
               A30LugarSectorPrecio = H000N3_A30LugarSectorPrecio[0];
               AssignAttri(sPrefix, false, "A30LugarSectorPrecio", StringUtil.LTrimStr( (decimal)(A30LugarSectorPrecio), 4, 0));
               A28LugarSectorName = H000N3_A28LugarSectorName[0];
               AssignAttri(sPrefix, false, "A28LugarSectorName", A28LugarSectorName);
               A29LugarSectorCantidad = H000N3_A29LugarSectorCantidad[0];
               A8TipoEspectaculoName = H000N3_A8TipoEspectaculoName[0];
               AssignAttri(sPrefix, false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
               A48EspectaculoFuncionName = H000N3_A48EspectaculoFuncionName[0];
               AssignAttri(sPrefix, false, "A48EspectaculoFuncionName", A48EspectaculoFuncionName);
               A37LugarSectorVendidas = H000N3_A37LugarSectorVendidas[0];
               n37LugarSectorVendidas = H000N3_n37LugarSectorVendidas[0];
               A3PaisId = H000N3_A3PaisId[0];
               AssignAttri(sPrefix, false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
               A10ClienteName = H000N3_A10ClienteName[0];
               AssignAttri(sPrefix, false, "A10ClienteName", A10ClienteName);
               A6PaisName = H000N3_A6PaisName[0];
               AssignAttri(sPrefix, false, "A6PaisName", A6PaisName);
               A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
               AssignAttri(sPrefix, false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
               /* Execute user event: Load */
               E140N2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0N0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0N2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "EntradaGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130N2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA23EntradaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA23EntradaId"), ",", "."));
            /* Read variables values. */
            A42EntradaFecha = context.localUtil.CToD( cgiGet( edtEntradaFecha_Internalname), 2);
            AssignAttri(sPrefix, false, "A42EntradaFecha", context.localUtil.Format(A42EntradaFecha, "99/99/99"));
            A9ClienteId = (short)(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            A10ClienteName = cgiGet( edtClienteName_Internalname);
            AssignAttri(sPrefix, false, "A10ClienteName", A10ClienteName);
            A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
            n1EspectaculoId = false;
            AssignAttri(sPrefix, false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A2EspectaculoName = cgiGet( edtEspectaculoName_Internalname);
            AssignAttri(sPrefix, false, "A2EspectaculoName", A2EspectaculoName);
            A16EspectaculoFecha = context.localUtil.CToD( cgiGet( edtEspectaculoFecha_Internalname), 2);
            AssignAttri(sPrefix, false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
            A6PaisName = cgiGet( edtPaisName_Internalname);
            AssignAttri(sPrefix, false, "A6PaisName", A6PaisName);
            A5LugarName = cgiGet( edtLugarName_Internalname);
            AssignAttri(sPrefix, false, "A5LugarName", A5LugarName);
            A27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", "."));
            n27LugarSectorId = false;
            AssignAttri(sPrefix, false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
            A38LugarSectorDisponibles = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorDisponibles_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
            A8TipoEspectaculoName = cgiGet( edtTipoEspectaculoName_Internalname);
            AssignAttri(sPrefix, false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            A47EspectaculoFuncionId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoFuncionId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A47EspectaculoFuncionId", StringUtil.LTrimStr( (decimal)(A47EspectaculoFuncionId), 4, 0));
            A48EspectaculoFuncionName = cgiGet( edtEspectaculoFuncionName_Internalname);
            AssignAttri(sPrefix, false, "A48EspectaculoFuncionName", A48EspectaculoFuncionName);
            A3PaisId = (short)(context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            A50EspectaculoPaisName = cgiGet( edtEspectaculoPaisName_Internalname);
            AssignAttri(sPrefix, false, "A50EspectaculoPaisName", A50EspectaculoPaisName);
            A28LugarSectorName = cgiGet( edtLugarSectorName_Internalname);
            AssignAttri(sPrefix, false, "A28LugarSectorName", A28LugarSectorName);
            A30LugarSectorPrecio = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorPrecio_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A30LugarSectorPrecio", StringUtil.LTrimStr( (decimal)(A30LugarSectorPrecio), 4, 0));
            A26EspectaculoImagen = cgiGet( imgEspectaculoImagen_Internalname);
            AssignAttri(sPrefix, false, "A26EspectaculoImagen", A26EspectaculoImagen);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EntradaGeneral");
            A9ClienteId = (short)(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            forbiddenHiddens.Add("ClienteId", context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9"));
            A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
            n1EspectaculoId = false;
            AssignAttri(sPrefix, false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("entradageneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E130N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130N2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140N2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtClienteName_Link = formatLink("viewcliente.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9ClienteId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ClienteId","TabCode"}) ;
         AssignProp(sPrefix, false, edtClienteName_Internalname, "Link", edtClienteName_Link, true);
         edtEspectaculoName_Link = formatLink("viewespectaculo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EspectaculoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"EspectaculoId","TabCode"}) ;
         AssignProp(sPrefix, false, edtEspectaculoName_Internalname, "Link", edtEspectaculoName_Link, true);
         edtPaisName_Link = formatLink("viewpais.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A3PaisId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"PaisId","TabCode"}) ;
         AssignProp(sPrefix, false, edtPaisName_Internalname, "Link", edtPaisName_Link, true);
         edtLugarName_Link = formatLink("viewlugar.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A4LugarId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"LugarId","TabCode"}) ;
         AssignProp(sPrefix, false, edtLugarName_Internalname, "Link", edtLugarName_Link, true);
         edtTipoEspectaculoName_Link = formatLink("viewtipoespectaculo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A7TipoEspectaculoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"TipoEspectaculoId","TabCode"}) ;
         AssignProp(sPrefix, false, edtTipoEspectaculoName_Internalname, "Link", edtTipoEspectaculoName_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Entrada";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "EntradaId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6EntradaId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A23EntradaId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
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
         PA0N2( ) ;
         WS0N2( ) ;
         WE0N2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA23EntradaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0N2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "entradageneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0N2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A23EntradaId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
         }
         wcpOA23EntradaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA23EntradaId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A23EntradaId != wcpOA23EntradaId ) ) )
         {
            setjustcreated();
         }
         wcpOA23EntradaId = A23EntradaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA23EntradaId = cgiGet( sPrefix+"A23EntradaId_CTRL");
         if ( StringUtil.Len( sCtrlA23EntradaId) > 0 )
         {
            A23EntradaId = (short)(context.localUtil.CToN( cgiGet( sCtrlA23EntradaId), ",", "."));
            AssignAttri(sPrefix, false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
         }
         else
         {
            A23EntradaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A23EntradaId_PARM"), ",", "."));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0N2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0N2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A23EntradaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23EntradaId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA23EntradaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A23EntradaId_CTRL", StringUtil.RTrim( sCtrlA23EntradaId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0N2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228111849565", true, true);
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
         context.AddJavascriptSource("entradageneral.js", "?20228111849565", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtEntradaId_Internalname = sPrefix+"ENTRADAID";
         edtEntradaFecha_Internalname = sPrefix+"ENTRADAFECHA";
         edtClienteId_Internalname = sPrefix+"CLIENTEID";
         edtClienteName_Internalname = sPrefix+"CLIENTENAME";
         edtEspectaculoId_Internalname = sPrefix+"ESPECTACULOID";
         edtEspectaculoName_Internalname = sPrefix+"ESPECTACULONAME";
         edtEspectaculoFecha_Internalname = sPrefix+"ESPECTACULOFECHA";
         edtPaisName_Internalname = sPrefix+"PAISNAME";
         edtLugarName_Internalname = sPrefix+"LUGARNAME";
         edtLugarSectorId_Internalname = sPrefix+"LUGARSECTORID";
         edtLugarSectorDisponibles_Internalname = sPrefix+"LUGARSECTORDISPONIBLES";
         edtTipoEspectaculoName_Internalname = sPrefix+"TIPOESPECTACULONAME";
         edtEspectaculoFuncionId_Internalname = sPrefix+"ESPECTACULOFUNCIONID";
         edtEspectaculoFuncionName_Internalname = sPrefix+"ESPECTACULOFUNCIONNAME";
         edtPaisId_Internalname = sPrefix+"PAISID";
         edtEspectaculoPaisName_Internalname = sPrefix+"ESPECTACULOPAISNAME";
         edtLugarSectorName_Internalname = sPrefix+"LUGARSECTORNAME";
         edtLugarSectorPrecio_Internalname = sPrefix+"LUGARSECTORPRECIO";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         imgEspectaculoImagen_Internalname = sPrefix+"ESPECTACULOIMAGEN";
         divImagestable_Internalname = sPrefix+"IMAGESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtLugarSectorPrecio_Jsonclick = "";
         edtLugarSectorPrecio_Enabled = 0;
         edtLugarSectorName_Jsonclick = "";
         edtLugarSectorName_Enabled = 0;
         edtEspectaculoPaisName_Jsonclick = "";
         edtEspectaculoPaisName_Enabled = 0;
         edtPaisId_Jsonclick = "";
         edtPaisId_Enabled = 0;
         edtEspectaculoFuncionName_Jsonclick = "";
         edtEspectaculoFuncionName_Enabled = 0;
         edtEspectaculoFuncionId_Jsonclick = "";
         edtEspectaculoFuncionId_Enabled = 0;
         edtTipoEspectaculoName_Jsonclick = "";
         edtTipoEspectaculoName_Link = "";
         edtTipoEspectaculoName_Enabled = 0;
         edtLugarSectorDisponibles_Jsonclick = "";
         edtLugarSectorDisponibles_Enabled = 0;
         edtLugarSectorId_Jsonclick = "";
         edtLugarSectorId_Enabled = 0;
         edtLugarName_Jsonclick = "";
         edtLugarName_Link = "";
         edtLugarName_Enabled = 0;
         edtPaisName_Jsonclick = "";
         edtPaisName_Link = "";
         edtPaisName_Enabled = 0;
         edtEspectaculoFecha_Jsonclick = "";
         edtEspectaculoFecha_Enabled = 0;
         edtEspectaculoName_Jsonclick = "";
         edtEspectaculoName_Link = "";
         edtEspectaculoName_Enabled = 0;
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 0;
         edtClienteName_Jsonclick = "";
         edtClienteName_Link = "";
         edtClienteName_Enabled = 0;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 0;
         edtEntradaFecha_Jsonclick = "";
         edtEntradaFecha_Enabled = 0;
         edtEntradaId_Jsonclick = "";
         edtEntradaId_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A23EntradaId',fld:'ENTRADAID',pic:'ZZZ9'},{av:'A9ClienteId',fld:'CLIENTEID',pic:'ZZZ9'},{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E110N1',iparms:[{av:'A23EntradaId',fld:'ENTRADAID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E120N1',iparms:[{av:'A23EntradaId',fld:'ENTRADAID',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_ENTRADAID","{handler:'Valid_Entradaid',iparms:[]");
         setEventMetadata("VALID_ENTRADAID",",oparms:[]}");
         setEventMetadata("VALID_CLIENTEID","{handler:'Valid_Clienteid',iparms:[]");
         setEventMetadata("VALID_CLIENTEID",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[]}");
         setEventMetadata("VALID_LUGARSECTORID","{handler:'Valid_Lugarsectorid',iparms:[]");
         setEventMetadata("VALID_LUGARSECTORID",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOFUNCIONID","{handler:'Valid_Espectaculofuncionid',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOFUNCIONID",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[]");
         setEventMetadata("VALID_PAISID",",oparms:[]}");
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
         sPrefix = "";
         AV13Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A42EntradaFecha = DateTime.MinValue;
         A10ClienteName = "";
         A2EspectaculoName = "";
         A16EspectaculoFecha = DateTime.MinValue;
         A6PaisName = "";
         A5LugarName = "";
         A8TipoEspectaculoName = "";
         A48EspectaculoFuncionName = "";
         A50EspectaculoPaisName = "";
         A28LugarSectorName = "";
         A26EspectaculoImagen = "";
         A40000EspectaculoImagen_GXI = "";
         sImgUrl = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000N3_A23EntradaId = new short[1] ;
         H000N3_A4LugarId = new short[1] ;
         H000N3_A7TipoEspectaculoId = new short[1] ;
         H000N3_A40000EspectaculoImagen_GXI = new string[] {""} ;
         H000N3_A30LugarSectorPrecio = new short[1] ;
         H000N3_A28LugarSectorName = new string[] {""} ;
         H000N3_A50EspectaculoPaisName = new string[] {""} ;
         H000N3_A3PaisId = new short[1] ;
         H000N3_A48EspectaculoFuncionName = new string[] {""} ;
         H000N3_A47EspectaculoFuncionId = new short[1] ;
         H000N3_A8TipoEspectaculoName = new string[] {""} ;
         H000N3_A27LugarSectorId = new short[1] ;
         H000N3_n27LugarSectorId = new bool[] {false} ;
         H000N3_A5LugarName = new string[] {""} ;
         H000N3_A6PaisName = new string[] {""} ;
         H000N3_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         H000N3_A2EspectaculoName = new string[] {""} ;
         H000N3_A1EspectaculoId = new short[1] ;
         H000N3_n1EspectaculoId = new bool[] {false} ;
         H000N3_A10ClienteName = new string[] {""} ;
         H000N3_A9ClienteId = new short[1] ;
         H000N3_A42EntradaFecha = new DateTime[] {DateTime.MinValue} ;
         H000N3_A29LugarSectorCantidad = new short[1] ;
         H000N3_A37LugarSectorVendidas = new short[1] ;
         H000N3_n37LugarSectorVendidas = new bool[] {false} ;
         H000N3_A26EspectaculoImagen = new string[] {""} ;
         hsh = "";
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA23EntradaId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.entradageneral__default(),
            new Object[][] {
                new Object[] {
               H000N3_A23EntradaId, H000N3_A4LugarId, H000N3_A7TipoEspectaculoId, H000N3_A40000EspectaculoImagen_GXI, H000N3_A30LugarSectorPrecio, H000N3_A28LugarSectorName, H000N3_A50EspectaculoPaisName, H000N3_A3PaisId, H000N3_A48EspectaculoFuncionName, H000N3_A47EspectaculoFuncionId,
               H000N3_A8TipoEspectaculoName, H000N3_A27LugarSectorId, H000N3_n27LugarSectorId, H000N3_A5LugarName, H000N3_A6PaisName, H000N3_A16EspectaculoFecha, H000N3_A2EspectaculoName, H000N3_A1EspectaculoId, H000N3_n1EspectaculoId, H000N3_A10ClienteName,
               H000N3_A9ClienteId, H000N3_A42EntradaFecha, H000N3_A29LugarSectorCantidad, H000N3_A37LugarSectorVendidas, H000N3_n37LugarSectorVendidas, H000N3_A26EspectaculoImagen
               }
            }
         );
         AV13Pgmname = "EntradaGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "EntradaGeneral";
         context.Gx_err = 0;
      }

      private short A23EntradaId ;
      private short wcpOA23EntradaId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short A9ClienteId ;
      private short A1EspectaculoId ;
      private short A29LugarSectorCantidad ;
      private short A37LugarSectorVendidas ;
      private short wbEnd ;
      private short wbStart ;
      private short A27LugarSectorId ;
      private short A38LugarSectorDisponibles ;
      private short A47EspectaculoFuncionId ;
      private short A3PaisId ;
      private short A30LugarSectorPrecio ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A4LugarId ;
      private short A7TipoEspectaculoId ;
      private short AV6EntradaId ;
      private short nGXWrapped ;
      private int edtEntradaId_Enabled ;
      private int edtEntradaFecha_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtClienteName_Enabled ;
      private int edtEspectaculoId_Enabled ;
      private int edtEspectaculoName_Enabled ;
      private int edtEspectaculoFecha_Enabled ;
      private int edtPaisName_Enabled ;
      private int edtLugarName_Enabled ;
      private int edtLugarSectorId_Enabled ;
      private int edtLugarSectorDisponibles_Enabled ;
      private int edtTipoEspectaculoName_Enabled ;
      private int edtEspectaculoFuncionId_Enabled ;
      private int edtEspectaculoFuncionName_Enabled ;
      private int edtPaisId_Enabled ;
      private int edtEspectaculoPaisName_Enabled ;
      private int edtLugarSectorName_Enabled ;
      private int edtLugarSectorPrecio_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtEntradaId_Internalname ;
      private string edtEntradaId_Jsonclick ;
      private string edtEntradaFecha_Internalname ;
      private string edtEntradaFecha_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteName_Internalname ;
      private string edtClienteName_Link ;
      private string edtClienteName_Jsonclick ;
      private string edtEspectaculoId_Internalname ;
      private string edtEspectaculoId_Jsonclick ;
      private string edtEspectaculoName_Internalname ;
      private string edtEspectaculoName_Link ;
      private string edtEspectaculoName_Jsonclick ;
      private string edtEspectaculoFecha_Internalname ;
      private string edtEspectaculoFecha_Jsonclick ;
      private string edtPaisName_Internalname ;
      private string edtPaisName_Link ;
      private string edtPaisName_Jsonclick ;
      private string edtLugarName_Internalname ;
      private string edtLugarName_Link ;
      private string edtLugarName_Jsonclick ;
      private string edtLugarSectorId_Internalname ;
      private string edtLugarSectorId_Jsonclick ;
      private string edtLugarSectorDisponibles_Internalname ;
      private string edtLugarSectorDisponibles_Jsonclick ;
      private string edtTipoEspectaculoName_Internalname ;
      private string edtTipoEspectaculoName_Link ;
      private string edtTipoEspectaculoName_Jsonclick ;
      private string edtEspectaculoFuncionId_Internalname ;
      private string edtEspectaculoFuncionId_Jsonclick ;
      private string edtEspectaculoFuncionName_Internalname ;
      private string edtEspectaculoFuncionName_Jsonclick ;
      private string edtPaisId_Internalname ;
      private string edtPaisId_Jsonclick ;
      private string edtEspectaculoPaisName_Internalname ;
      private string edtEspectaculoPaisName_Jsonclick ;
      private string edtLugarSectorName_Internalname ;
      private string edtLugarSectorName_Jsonclick ;
      private string edtLugarSectorPrecio_Internalname ;
      private string edtLugarSectorPrecio_Jsonclick ;
      private string divImagestable_Internalname ;
      private string sImgUrl ;
      private string imgEspectaculoImagen_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string hsh ;
      private string sCtrlA23EntradaId ;
      private DateTime A42EntradaFecha ;
      private DateTime A16EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A26EspectaculoImagen_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n27LugarSectorId ;
      private bool n1EspectaculoId ;
      private bool n37LugarSectorVendidas ;
      private bool returnInSub ;
      private string A10ClienteName ;
      private string A2EspectaculoName ;
      private string A6PaisName ;
      private string A5LugarName ;
      private string A8TipoEspectaculoName ;
      private string A48EspectaculoFuncionName ;
      private string A50EspectaculoPaisName ;
      private string A28LugarSectorName ;
      private string A40000EspectaculoImagen_GXI ;
      private string A26EspectaculoImagen ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000N3_A23EntradaId ;
      private short[] H000N3_A4LugarId ;
      private short[] H000N3_A7TipoEspectaculoId ;
      private string[] H000N3_A40000EspectaculoImagen_GXI ;
      private short[] H000N3_A30LugarSectorPrecio ;
      private string[] H000N3_A28LugarSectorName ;
      private string[] H000N3_A50EspectaculoPaisName ;
      private short[] H000N3_A3PaisId ;
      private string[] H000N3_A48EspectaculoFuncionName ;
      private short[] H000N3_A47EspectaculoFuncionId ;
      private string[] H000N3_A8TipoEspectaculoName ;
      private short[] H000N3_A27LugarSectorId ;
      private bool[] H000N3_n27LugarSectorId ;
      private string[] H000N3_A5LugarName ;
      private string[] H000N3_A6PaisName ;
      private DateTime[] H000N3_A16EspectaculoFecha ;
      private string[] H000N3_A2EspectaculoName ;
      private short[] H000N3_A1EspectaculoId ;
      private bool[] H000N3_n1EspectaculoId ;
      private string[] H000N3_A10ClienteName ;
      private short[] H000N3_A9ClienteId ;
      private DateTime[] H000N3_A42EntradaFecha ;
      private short[] H000N3_A29LugarSectorCantidad ;
      private short[] H000N3_A37LugarSectorVendidas ;
      private bool[] H000N3_n37LugarSectorVendidas ;
      private string[] H000N3_A26EspectaculoImagen ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class entradageneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000N3;
          prmH000N3 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000N3", "SELECT T1.[EntradaId], T2.[LugarId], T2.[TipoEspectaculoId], T2.[EspectaculoImagen_GXI], T4.[LugarSectorPrecio], T4.[LugarSectorName], T1.[EspectaculoPaisName], T8.[PaisId], T6.[EspectaculoFuncionName], T1.[EspectaculoFuncionId], T5.[TipoEspectaculoName], T1.[LugarSectorId], T3.[LugarName], T9.[PaisName], T2.[EspectaculoFecha], T2.[EspectaculoName], T1.[EspectaculoId], T8.[ClienteName], T1.[ClienteId], T1.[EntradaFecha], T4.[LugarSectorCantidad], COALESCE( T7.[LugarSectorVendidas], 0) AS LugarSectorVendidas, T2.[EspectaculoImagen] FROM (((((((([Entrada] T1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = T1.[EspectaculoId]) INNER JOIN [Lugar] T3 ON T3.[LugarId] = T2.[LugarId]) LEFT JOIN [LugarSector] T4 ON T4.[LugarId] = T2.[LugarId] AND T4.[LugarSectorId] = T1.[LugarSectorId]) INNER JOIN [TipoEspectaculo] T5 ON T5.[TipoEspectaculoId] = T2.[TipoEspectaculoId]) INNER JOIN [EspectaculoFuncion] T6 ON T6.[EspectaculoId] = T1.[EspectaculoId] AND T6.[EspectaculoFuncionId] = T1.[EspectaculoFuncionId]) LEFT JOIN (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T7 ON T7.[EspectaculoId] = T1.[EspectaculoId] AND T7.[LugarSectorId] = T1.[LugarSectorId]) INNER JOIN [Cliente] T8 ON T8.[ClienteId] = T1.[ClienteId]) INNER JOIN [Pais] T9 ON T9.[PaisId] = T8.[PaisId]) WHERE T1.[EntradaId] = @EntradaId ORDER BY T1.[EntradaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000N3,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(15);
                ((string[]) buf[16])[0] = rslt.getVarchar(16);
                ((short[]) buf[17])[0] = rslt.getShort(17);
                ((bool[]) buf[18])[0] = rslt.wasNull(17);
                ((string[]) buf[19])[0] = rslt.getVarchar(18);
                ((short[]) buf[20])[0] = rslt.getShort(19);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(20);
                ((short[]) buf[22])[0] = rslt.getShort(21);
                ((short[]) buf[23])[0] = rslt.getShort(22);
                ((bool[]) buf[24])[0] = rslt.wasNull(22);
                ((string[]) buf[25])[0] = rslt.getMultimediaFile(23, rslt.getVarchar(4));
                return;
       }
    }

 }

}
