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
   public class ventageneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public ventageneral( )
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

      public ventageneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_VentaId )
      {
         this.A11VentaId = aP0_VentaId;
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
               gxfirstwebparm = GetFirstPar( "VentaId");
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
                  A11VentaId = (short)(NumberUtil.Val( GetPar( "VentaId"), "."));
                  AssignAttri(sPrefix, false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A11VentaId});
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
                  gxfirstwebparm = GetFirstPar( "VentaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "VentaId");
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
            PA0K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "VentaGeneral";
               context.Gx_err = 0;
               WS0K2( ) ;
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
            context.SendWebValue( "Venta General") ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 552120), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20228822543671", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ventageneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A11VentaId,4,0))}, new string[] {"VentaId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"VentaGeneral");
         forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"));
         forbiddenHiddens.Add("ClienteId", context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("ventageneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA11VentaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA11VentaId), 4, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm0K2( )
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
         return "VentaGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Venta General" ;
      }

      protected void WB0K0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "ventageneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modificar", bttBtnupdate_Jsonclick, 7, "Modificar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110k1_client"+"'", TempTags, "", 2, "HLP_VentaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 7, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120k1_client"+"'", TempTags, "", 2, "HLP_VentaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVentaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVentaId_Internalname, "Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVentaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11VentaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtVentaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A11VentaId), "ZZZ9") : context.localUtil.Format( (decimal)(A11VentaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVentaId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVentaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_VentaGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_VentaGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtEspectaculoName_Internalname, A2EspectaculoName, StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtEspectaculoName_Link, "", "", "", edtEspectaculoName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_VentaGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoName_Internalname, A8TipoEspectaculoName, StringUtil.RTrim( context.localUtil.Format( A8TipoEspectaculoName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtTipoEspectaculoName_Link, "", "", "", edtTipoEspectaculoName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtTipoEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_VentaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtValorPorAsiento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtValorPorAsiento_Internalname, "Por Asiento", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtValorPorAsiento_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ValorPorAsiento), 4, 0, ",", "")), StringUtil.LTrim( ((edtValorPorAsiento_Enabled!=0) ? context.localUtil.Format( (decimal)(A12ValorPorAsiento), "ZZZ9") : context.localUtil.Format( (decimal)(A12ValorPorAsiento), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtValorPorAsiento_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtValorPorAsiento_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_VentaGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPaisId_Enabled!=0) ? context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9") : context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaisId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_VentaGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtPaisName_Internalname, A6PaisName, StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtPaisName_Link, "", "", "", edtPaisName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaisName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_VentaGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteId), 4, 0, ",", "")), StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9") : context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_VentaGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtClienteName_Internalname, A10ClienteName, StringUtil.RTrim( context.localUtil.Format( A10ClienteName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtClienteName_Link, "", "", "", edtClienteName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_VentaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoSectorName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoSectorName_Internalname, "Espectaculo Sector Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoSectorName_Internalname, A32EspectaculoSectorName, StringUtil.RTrim( context.localUtil.Format( A32EspectaculoSectorName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoSectorName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoSectorName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_VentaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoSectorPrecio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoSectorPrecio_Internalname, "Espectaculo Sector Precio", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A35EspectaculoSectorPrecio), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A35EspectaculoSectorPrecio), "ZZZ9") : context.localUtil.Format( (decimal)(A35EspectaculoSectorPrecio), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoSectorPrecio_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoSectorPrecio_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_VentaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoSectorId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoSectorId_Internalname, "Espectaculo Sector Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoSectorId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoSectorId_Enabled!=0) ? context.localUtil.Format( (decimal)(A31EspectaculoSectorId), "ZZZ9") : context.localUtil.Format( (decimal)(A31EspectaculoSectorId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoSectorId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoSectorId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_VentaGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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

      protected void START0K2( )
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
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_10-161416", 0) ;
               }
               Form.Meta.addItem("description", "Venta General", 0) ;
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
               STRUP0K0( ) ;
            }
         }
      }

      protected void WS0K2( )
      {
         START0K2( ) ;
         EVT0K2( ) ;
      }

      protected void EVT0K2( )
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
                                 STRUP0K0( ) ;
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
                                 STRUP0K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0K0( ) ;
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
                                 STRUP0K0( ) ;
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

      protected void WE0K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0K2( ) ;
            }
         }
      }

      protected void PA0K2( )
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
         RF0K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "VentaGeneral";
         context.Gx_err = 0;
      }

      protected void RF0K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000K2 */
            pr_default.execute(0, new Object[] {A11VentaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A4LugarId = H000K2_A4LugarId[0];
               A7TipoEspectaculoId = H000K2_A7TipoEspectaculoId[0];
               A31EspectaculoSectorId = H000K2_A31EspectaculoSectorId[0];
               AssignAttri(sPrefix, false, "A31EspectaculoSectorId", StringUtil.LTrimStr( (decimal)(A31EspectaculoSectorId), 4, 0));
               A35EspectaculoSectorPrecio = H000K2_A35EspectaculoSectorPrecio[0];
               AssignAttri(sPrefix, false, "A35EspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(A35EspectaculoSectorPrecio), 4, 0));
               A32EspectaculoSectorName = H000K2_A32EspectaculoSectorName[0];
               AssignAttri(sPrefix, false, "A32EspectaculoSectorName", A32EspectaculoSectorName);
               A10ClienteName = H000K2_A10ClienteName[0];
               AssignAttri(sPrefix, false, "A10ClienteName", A10ClienteName);
               A9ClienteId = H000K2_A9ClienteId[0];
               AssignAttri(sPrefix, false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
               A6PaisName = H000K2_A6PaisName[0];
               AssignAttri(sPrefix, false, "A6PaisName", A6PaisName);
               A3PaisId = H000K2_A3PaisId[0];
               AssignAttri(sPrefix, false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
               A12ValorPorAsiento = H000K2_A12ValorPorAsiento[0];
               AssignAttri(sPrefix, false, "A12ValorPorAsiento", StringUtil.LTrimStr( (decimal)(A12ValorPorAsiento), 4, 0));
               A8TipoEspectaculoName = H000K2_A8TipoEspectaculoName[0];
               AssignAttri(sPrefix, false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
               A2EspectaculoName = H000K2_A2EspectaculoName[0];
               AssignAttri(sPrefix, false, "A2EspectaculoName", A2EspectaculoName);
               A1EspectaculoId = H000K2_A1EspectaculoId[0];
               AssignAttri(sPrefix, false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               A10ClienteName = H000K2_A10ClienteName[0];
               AssignAttri(sPrefix, false, "A10ClienteName", A10ClienteName);
               A4LugarId = H000K2_A4LugarId[0];
               A7TipoEspectaculoId = H000K2_A7TipoEspectaculoId[0];
               A2EspectaculoName = H000K2_A2EspectaculoName[0];
               AssignAttri(sPrefix, false, "A2EspectaculoName", A2EspectaculoName);
               A3PaisId = H000K2_A3PaisId[0];
               AssignAttri(sPrefix, false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
               A6PaisName = H000K2_A6PaisName[0];
               AssignAttri(sPrefix, false, "A6PaisName", A6PaisName);
               A8TipoEspectaculoName = H000K2_A8TipoEspectaculoName[0];
               AssignAttri(sPrefix, false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
               A35EspectaculoSectorPrecio = H000K2_A35EspectaculoSectorPrecio[0];
               AssignAttri(sPrefix, false, "A35EspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(A35EspectaculoSectorPrecio), 4, 0));
               A32EspectaculoSectorName = H000K2_A32EspectaculoSectorName[0];
               AssignAttri(sPrefix, false, "A32EspectaculoSectorName", A32EspectaculoSectorName);
               /* Execute user event: Load */
               E140K2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0K2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "VentaGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130K2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA11VentaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA11VentaId"), ",", "."));
            /* Read variables values. */
            A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A2EspectaculoName = cgiGet( edtEspectaculoName_Internalname);
            AssignAttri(sPrefix, false, "A2EspectaculoName", A2EspectaculoName);
            A8TipoEspectaculoName = cgiGet( edtTipoEspectaculoName_Internalname);
            AssignAttri(sPrefix, false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            A12ValorPorAsiento = (short)(context.localUtil.CToN( cgiGet( edtValorPorAsiento_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A12ValorPorAsiento", StringUtil.LTrimStr( (decimal)(A12ValorPorAsiento), 4, 0));
            A3PaisId = (short)(context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            A6PaisName = cgiGet( edtPaisName_Internalname);
            AssignAttri(sPrefix, false, "A6PaisName", A6PaisName);
            A9ClienteId = (short)(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            A10ClienteName = cgiGet( edtClienteName_Internalname);
            AssignAttri(sPrefix, false, "A10ClienteName", A10ClienteName);
            A32EspectaculoSectorName = cgiGet( edtEspectaculoSectorName_Internalname);
            AssignAttri(sPrefix, false, "A32EspectaculoSectorName", A32EspectaculoSectorName);
            A35EspectaculoSectorPrecio = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoSectorPrecio_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A35EspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(A35EspectaculoSectorPrecio), 4, 0));
            A31EspectaculoSectorId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoSectorId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A31EspectaculoSectorId", StringUtil.LTrimStr( (decimal)(A31EspectaculoSectorId), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"VentaGeneral");
            A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"));
            A9ClienteId = (short)(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            forbiddenHiddens.Add("ClienteId", context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("ventageneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E130K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130K2( )
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

      protected void E140K2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtEspectaculoName_Link = formatLink("viewespectaculo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EspectaculoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"EspectaculoId","TabCode"}) ;
         AssignProp(sPrefix, false, edtEspectaculoName_Internalname, "Link", edtEspectaculoName_Link, true);
         edtTipoEspectaculoName_Link = formatLink("viewtipoespectaculo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A7TipoEspectaculoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"TipoEspectaculoId","TabCode"}) ;
         AssignProp(sPrefix, false, edtTipoEspectaculoName_Internalname, "Link", edtTipoEspectaculoName_Link, true);
         edtPaisName_Link = formatLink("viewpais.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A3PaisId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"PaisId","TabCode"}) ;
         AssignProp(sPrefix, false, edtPaisName_Internalname, "Link", edtPaisName_Link, true);
         edtClienteName_Link = formatLink("viewcliente.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9ClienteId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ClienteId","TabCode"}) ;
         AssignProp(sPrefix, false, edtClienteName_Internalname, "Link", edtClienteName_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Venta";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "VentaId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6VentaId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A11VentaId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
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
         PA0K2( ) ;
         WS0K2( ) ;
         WE0K2( ) ;
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
         sCtrlA11VentaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0K2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "ventageneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0K2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A11VentaId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
         }
         wcpOA11VentaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA11VentaId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A11VentaId != wcpOA11VentaId ) ) )
         {
            setjustcreated();
         }
         wcpOA11VentaId = A11VentaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA11VentaId = cgiGet( sPrefix+"A11VentaId_CTRL");
         if ( StringUtil.Len( sCtrlA11VentaId) > 0 )
         {
            A11VentaId = (short)(context.localUtil.CToN( cgiGet( sCtrlA11VentaId), ",", "."));
            AssignAttri(sPrefix, false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
         }
         else
         {
            A11VentaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A11VentaId_PARM"), ",", "."));
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
         PA0K2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0K2( ) ;
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
         WS0K2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A11VentaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11VentaId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA11VentaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A11VentaId_CTRL", StringUtil.RTrim( sCtrlA11VentaId));
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
         WE0K2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228822543696", true, true);
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
         context.AddJavascriptSource("ventageneral.js", "?20228822543696", false, true);
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
         edtVentaId_Internalname = sPrefix+"VENTAID";
         edtEspectaculoId_Internalname = sPrefix+"ESPECTACULOID";
         edtEspectaculoName_Internalname = sPrefix+"ESPECTACULONAME";
         edtTipoEspectaculoName_Internalname = sPrefix+"TIPOESPECTACULONAME";
         edtValorPorAsiento_Internalname = sPrefix+"VALORPORASIENTO";
         edtPaisId_Internalname = sPrefix+"PAISID";
         edtPaisName_Internalname = sPrefix+"PAISNAME";
         edtClienteId_Internalname = sPrefix+"CLIENTEID";
         edtClienteName_Internalname = sPrefix+"CLIENTENAME";
         edtEspectaculoSectorName_Internalname = sPrefix+"ESPECTACULOSECTORNAME";
         edtEspectaculoSectorPrecio_Internalname = sPrefix+"ESPECTACULOSECTORPRECIO";
         edtEspectaculoSectorId_Internalname = sPrefix+"ESPECTACULOSECTORID";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
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
         edtEspectaculoSectorId_Jsonclick = "";
         edtEspectaculoSectorId_Enabled = 0;
         edtEspectaculoSectorPrecio_Jsonclick = "";
         edtEspectaculoSectorPrecio_Enabled = 0;
         edtEspectaculoSectorName_Jsonclick = "";
         edtEspectaculoSectorName_Enabled = 0;
         edtClienteName_Jsonclick = "";
         edtClienteName_Link = "";
         edtClienteName_Enabled = 0;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 0;
         edtPaisName_Jsonclick = "";
         edtPaisName_Link = "";
         edtPaisName_Enabled = 0;
         edtPaisId_Jsonclick = "";
         edtPaisId_Enabled = 0;
         edtValorPorAsiento_Jsonclick = "";
         edtValorPorAsiento_Enabled = 0;
         edtTipoEspectaculoName_Jsonclick = "";
         edtTipoEspectaculoName_Link = "";
         edtTipoEspectaculoName_Enabled = 0;
         edtEspectaculoName_Jsonclick = "";
         edtEspectaculoName_Link = "";
         edtEspectaculoName_Enabled = 0;
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 0;
         edtVentaId_Jsonclick = "";
         edtVentaId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A11VentaId',fld:'VENTAID',pic:'ZZZ9'},{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A9ClienteId',fld:'CLIENTEID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E110K1',iparms:[{av:'A11VentaId',fld:'VENTAID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E120K1',iparms:[{av:'A11VentaId',fld:'VENTAID',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_VENTAID","{handler:'Valid_Ventaid',iparms:[]");
         setEventMetadata("VALID_VENTAID",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[]");
         setEventMetadata("VALID_PAISID",",oparms:[]}");
         setEventMetadata("VALID_CLIENTEID","{handler:'Valid_Clienteid',iparms:[]");
         setEventMetadata("VALID_CLIENTEID",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOSECTORID","{handler:'Valid_Espectaculosectorid',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOSECTORID",",oparms:[]}");
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
         A2EspectaculoName = "";
         A8TipoEspectaculoName = "";
         A6PaisName = "";
         A10ClienteName = "";
         A32EspectaculoSectorName = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000K2_A4LugarId = new short[1] ;
         H000K2_A11VentaId = new short[1] ;
         H000K2_A7TipoEspectaculoId = new short[1] ;
         H000K2_A31EspectaculoSectorId = new short[1] ;
         H000K2_A35EspectaculoSectorPrecio = new short[1] ;
         H000K2_A32EspectaculoSectorName = new string[] {""} ;
         H000K2_A10ClienteName = new string[] {""} ;
         H000K2_A9ClienteId = new short[1] ;
         H000K2_A6PaisName = new string[] {""} ;
         H000K2_A3PaisId = new short[1] ;
         H000K2_A12ValorPorAsiento = new short[1] ;
         H000K2_A8TipoEspectaculoName = new string[] {""} ;
         H000K2_A2EspectaculoName = new string[] {""} ;
         H000K2_A1EspectaculoId = new short[1] ;
         hsh = "";
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA11VentaId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventageneral__default(),
            new Object[][] {
                new Object[] {
               H000K2_A4LugarId, H000K2_A11VentaId, H000K2_A7TipoEspectaculoId, H000K2_A31EspectaculoSectorId, H000K2_A35EspectaculoSectorPrecio, H000K2_A32EspectaculoSectorName, H000K2_A10ClienteName, H000K2_A9ClienteId, H000K2_A6PaisName, H000K2_A3PaisId,
               H000K2_A12ValorPorAsiento, H000K2_A8TipoEspectaculoName, H000K2_A2EspectaculoName, H000K2_A1EspectaculoId
               }
            }
         );
         AV13Pgmname = "VentaGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "VentaGeneral";
         context.Gx_err = 0;
      }

      private short A11VentaId ;
      private short wcpOA11VentaId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short A1EspectaculoId ;
      private short A9ClienteId ;
      private short wbEnd ;
      private short wbStart ;
      private short A12ValorPorAsiento ;
      private short A3PaisId ;
      private short A35EspectaculoSectorPrecio ;
      private short A31EspectaculoSectorId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A4LugarId ;
      private short A7TipoEspectaculoId ;
      private short AV6VentaId ;
      private short nGXWrapped ;
      private int edtVentaId_Enabled ;
      private int edtEspectaculoId_Enabled ;
      private int edtEspectaculoName_Enabled ;
      private int edtTipoEspectaculoName_Enabled ;
      private int edtValorPorAsiento_Enabled ;
      private int edtPaisId_Enabled ;
      private int edtPaisName_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtClienteName_Enabled ;
      private int edtEspectaculoSectorName_Enabled ;
      private int edtEspectaculoSectorPrecio_Enabled ;
      private int edtEspectaculoSectorId_Enabled ;
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
      private string edtVentaId_Internalname ;
      private string edtVentaId_Jsonclick ;
      private string edtEspectaculoId_Internalname ;
      private string edtEspectaculoId_Jsonclick ;
      private string edtEspectaculoName_Internalname ;
      private string edtEspectaculoName_Link ;
      private string edtEspectaculoName_Jsonclick ;
      private string edtTipoEspectaculoName_Internalname ;
      private string edtTipoEspectaculoName_Link ;
      private string edtTipoEspectaculoName_Jsonclick ;
      private string edtValorPorAsiento_Internalname ;
      private string edtValorPorAsiento_Jsonclick ;
      private string edtPaisId_Internalname ;
      private string edtPaisId_Jsonclick ;
      private string edtPaisName_Internalname ;
      private string edtPaisName_Link ;
      private string edtPaisName_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteName_Internalname ;
      private string edtClienteName_Link ;
      private string edtClienteName_Jsonclick ;
      private string edtEspectaculoSectorName_Internalname ;
      private string edtEspectaculoSectorName_Jsonclick ;
      private string edtEspectaculoSectorPrecio_Internalname ;
      private string edtEspectaculoSectorPrecio_Jsonclick ;
      private string edtEspectaculoSectorId_Internalname ;
      private string edtEspectaculoSectorId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string hsh ;
      private string sCtrlA11VentaId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A2EspectaculoName ;
      private string A8TipoEspectaculoName ;
      private string A6PaisName ;
      private string A10ClienteName ;
      private string A32EspectaculoSectorName ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000K2_A4LugarId ;
      private short[] H000K2_A11VentaId ;
      private short[] H000K2_A7TipoEspectaculoId ;
      private short[] H000K2_A31EspectaculoSectorId ;
      private short[] H000K2_A35EspectaculoSectorPrecio ;
      private string[] H000K2_A32EspectaculoSectorName ;
      private string[] H000K2_A10ClienteName ;
      private short[] H000K2_A9ClienteId ;
      private string[] H000K2_A6PaisName ;
      private short[] H000K2_A3PaisId ;
      private short[] H000K2_A12ValorPorAsiento ;
      private string[] H000K2_A8TipoEspectaculoName ;
      private string[] H000K2_A2EspectaculoName ;
      private short[] H000K2_A1EspectaculoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class ventageneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000K2;
          prmH000K2 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000K2", "SELECT T3.[LugarId], T1.[VentaId], T3.[TipoEspectaculoId], T1.[EspectaculoSectorId], T7.[EspectaculoSectorPrecio], T7.[EspectaculoSectorName], T2.[ClienteName], T1.[ClienteId], T5.[PaisName], T4.[PaisId], T1.[ValorPorAsiento], T6.[TipoEspectaculoName], T3.[EspectaculoName], T1.[EspectaculoId] FROM (((((([Venta] T1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = T1.[ClienteId]) INNER JOIN [Espectaculo] T3 ON T3.[EspectaculoId] = T1.[EspectaculoId]) INNER JOIN [Lugar] T4 ON T4.[LugarId] = T3.[LugarId]) INNER JOIN [Pais] T5 ON T5.[PaisId] = T4.[PaisId]) INNER JOIN [TipoEspectaculo] T6 ON T6.[TipoEspectaculoId] = T3.[TipoEspectaculoId]) INNER JOIN [EspectaculoSector] T7 ON T7.[EspectaculoId] = T1.[EspectaculoId] AND T7.[EspectaculoSectorId] = T1.[EspectaculoSectorId]) WHERE T1.[VentaId] = @VentaId ORDER BY T1.[VentaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000K2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                return;
       }
    }

 }

}
