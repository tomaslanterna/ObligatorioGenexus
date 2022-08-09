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
   public class espectaculogeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public espectaculogeneral( )
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

      public espectaculogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_EspectaculoId )
      {
         this.A1EspectaculoId = aP0_EspectaculoId;
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
               gxfirstwebparm = GetFirstPar( "EspectaculoId");
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
                  A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
                  AssignAttri(sPrefix, false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A1EspectaculoId});
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
                  gxfirstwebparm = GetFirstPar( "EspectaculoId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "EspectaculoId");
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
            PA0Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "EspectaculoGeneral";
               context.Gx_err = 0;
               WS0Q2( ) ;
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
            context.SendWebValue( "Espectaculo General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2022882254314", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("espectaculogeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EspectaculoId,4,0))}, new string[] {"EspectaculoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EspectaculoGeneral");
         forbiddenHiddens.Add("LugarId", context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9"));
         forbiddenHiddens.Add("TipoEspectaculoId", context.localUtil.Format( (decimal)(A7TipoEspectaculoId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("espectaculogeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA1EspectaculoId), 4, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm0Q2( )
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
         return "EspectaculoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Espectaculo General" ;
      }

      protected void WB0Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "espectaculogeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modificar", bttBtnupdate_Jsonclick, 7, "Modificar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110q1_client"+"'", TempTags, "", 2, "HLP_EspectaculoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 7, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120q1_client"+"'", TempTags, "", 2, "HLP_EspectaculoGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEspectaculoId_Internalname, "Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_EspectaculoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEspectaculoName_Internalname, "Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEspectaculoName_Internalname, A2EspectaculoName, StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EspectaculoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPaisId_Enabled!=0) ? context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9") : context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaisId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_EspectaculoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtPaisName_Internalname, A6PaisName, StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtPaisName_Link, "", "", "", edtPaisName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaisName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EspectaculoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLugarId_Internalname, "Lugar Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtLugarId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ",", "")), StringUtil.LTrim( ((edtLugarId_Enabled!=0) ? context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9") : context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtLugarId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_EspectaculoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtLugarName_Internalname, A5LugarName, StringUtil.RTrim( context.localUtil.Format( A5LugarName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtLugarName_Link, "", "", "", edtLugarName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtLugarName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EspectaculoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipoEspectaculoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTipoEspectaculoId_Internalname, "Tipo Espectaculo Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtTipoEspectaculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A7TipoEspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(A7TipoEspectaculoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtTipoEspectaculoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_EspectaculoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoName_Internalname, A8TipoEspectaculoName, StringUtil.RTrim( context.localUtil.Format( A8TipoEspectaculoName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtTipoEspectaculoName_Link, "", "", "", edtTipoEspectaculoName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtTipoEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_EspectaculoGeneral.htm");
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
            GxWebStd.gx_label_element( context, "", "Imagen", "col-sm-3 ReadonlyAttributeLabel ReadonlyResponsiveImageAttributeLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
            StyleString = "";
            A26EspectaculoImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000EspectaculoImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.PathToRelativeUrl( A26EspectaculoImagen));
            GxWebStd.gx_bitmap( context, imgEspectaculoImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A26EspectaculoImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_EspectaculoGeneral.htm");
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

      protected void START0Q2( )
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
               Form.Meta.addItem("description", "Espectaculo General", 0) ;
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
               STRUP0Q0( ) ;
            }
         }
      }

      protected void WS0Q2( )
      {
         START0Q2( ) ;
         EVT0Q2( ) ;
      }

      protected void EVT0Q2( )
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
                                 STRUP0Q0( ) ;
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
                                 STRUP0Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Q0( ) ;
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
                                 STRUP0Q0( ) ;
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

      protected void WE0Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0Q2( ) ;
            }
         }
      }

      protected void PA0Q2( )
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
         RF0Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "EspectaculoGeneral";
         context.Gx_err = 0;
      }

      protected void RF0Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000Q2 */
            pr_default.execute(0, new Object[] {A1EspectaculoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A40000EspectaculoImagen_GXI = H000Q2_A40000EspectaculoImagen_GXI[0];
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
               A8TipoEspectaculoName = H000Q2_A8TipoEspectaculoName[0];
               AssignAttri(sPrefix, false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
               A7TipoEspectaculoId = H000Q2_A7TipoEspectaculoId[0];
               AssignAttri(sPrefix, false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
               A5LugarName = H000Q2_A5LugarName[0];
               AssignAttri(sPrefix, false, "A5LugarName", A5LugarName);
               A4LugarId = H000Q2_A4LugarId[0];
               AssignAttri(sPrefix, false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
               A6PaisName = H000Q2_A6PaisName[0];
               AssignAttri(sPrefix, false, "A6PaisName", A6PaisName);
               A3PaisId = H000Q2_A3PaisId[0];
               AssignAttri(sPrefix, false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
               A2EspectaculoName = H000Q2_A2EspectaculoName[0];
               AssignAttri(sPrefix, false, "A2EspectaculoName", A2EspectaculoName);
               A26EspectaculoImagen = H000Q2_A26EspectaculoImagen[0];
               AssignAttri(sPrefix, false, "A26EspectaculoImagen", A26EspectaculoImagen);
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
               AssignProp(sPrefix, false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
               A8TipoEspectaculoName = H000Q2_A8TipoEspectaculoName[0];
               AssignAttri(sPrefix, false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
               A5LugarName = H000Q2_A5LugarName[0];
               AssignAttri(sPrefix, false, "A5LugarName", A5LugarName);
               A3PaisId = H000Q2_A3PaisId[0];
               AssignAttri(sPrefix, false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
               A6PaisName = H000Q2_A6PaisName[0];
               AssignAttri(sPrefix, false, "A6PaisName", A6PaisName);
               /* Execute user event: Load */
               E140Q2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0Q2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "EspectaculoGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1EspectaculoId"), ",", "."));
            /* Read variables values. */
            A2EspectaculoName = cgiGet( edtEspectaculoName_Internalname);
            AssignAttri(sPrefix, false, "A2EspectaculoName", A2EspectaculoName);
            A3PaisId = (short)(context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            A6PaisName = cgiGet( edtPaisName_Internalname);
            AssignAttri(sPrefix, false, "A6PaisName", A6PaisName);
            A4LugarId = (short)(context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            A5LugarName = cgiGet( edtLugarName_Internalname);
            AssignAttri(sPrefix, false, "A5LugarName", A5LugarName);
            A7TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
            A8TipoEspectaculoName = cgiGet( edtTipoEspectaculoName_Internalname);
            AssignAttri(sPrefix, false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            A26EspectaculoImagen = cgiGet( imgEspectaculoImagen_Internalname);
            AssignAttri(sPrefix, false, "A26EspectaculoImagen", A26EspectaculoImagen);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EspectaculoGeneral");
            A4LugarId = (short)(context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            forbiddenHiddens.Add("LugarId", context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9"));
            A7TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", "."));
            AssignAttri(sPrefix, false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
            forbiddenHiddens.Add("TipoEspectaculoId", context.localUtil.Format( (decimal)(A7TipoEspectaculoId), "ZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("espectaculogeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E130Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130Q2( )
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

      protected void E140Q2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         AV7TrnContext.gxTpr_Transactionname = "Espectaculo";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "EspectaculoId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A1EspectaculoId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
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
         PA0Q2( ) ;
         WS0Q2( ) ;
         WE0Q2( ) ;
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
         sCtrlA1EspectaculoId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "espectaculogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0Q2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A1EspectaculoId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
         wcpOA1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1EspectaculoId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( A1EspectaculoId != wcpOA1EspectaculoId ) ) )
         {
            setjustcreated();
         }
         wcpOA1EspectaculoId = A1EspectaculoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA1EspectaculoId = cgiGet( sPrefix+"A1EspectaculoId_CTRL");
         if ( StringUtil.Len( sCtrlA1EspectaculoId) > 0 )
         {
            A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( sCtrlA1EspectaculoId), ",", "."));
            AssignAttri(sPrefix, false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
         else
         {
            A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A1EspectaculoId_PARM"), ",", "."));
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
         PA0Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0Q2( ) ;
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
         WS0Q2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A1EspectaculoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA1EspectaculoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A1EspectaculoId_CTRL", StringUtil.RTrim( sCtrlA1EspectaculoId));
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
         WE0Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228822543126", true, true);
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
         context.AddJavascriptSource("espectaculogeneral.js", "?20228822543126", false, true);
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
         edtEspectaculoId_Internalname = sPrefix+"ESPECTACULOID";
         edtEspectaculoName_Internalname = sPrefix+"ESPECTACULONAME";
         edtPaisId_Internalname = sPrefix+"PAISID";
         edtPaisName_Internalname = sPrefix+"PAISNAME";
         edtLugarId_Internalname = sPrefix+"LUGARID";
         edtLugarName_Internalname = sPrefix+"LUGARNAME";
         edtTipoEspectaculoId_Internalname = sPrefix+"TIPOESPECTACULOID";
         edtTipoEspectaculoName_Internalname = sPrefix+"TIPOESPECTACULONAME";
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
         edtTipoEspectaculoName_Jsonclick = "";
         edtTipoEspectaculoName_Link = "";
         edtTipoEspectaculoName_Enabled = 0;
         edtTipoEspectaculoId_Jsonclick = "";
         edtTipoEspectaculoId_Enabled = 0;
         edtLugarName_Jsonclick = "";
         edtLugarName_Link = "";
         edtLugarName_Enabled = 0;
         edtLugarId_Jsonclick = "";
         edtLugarId_Enabled = 0;
         edtPaisName_Jsonclick = "";
         edtPaisName_Link = "";
         edtPaisName_Enabled = 0;
         edtPaisId_Jsonclick = "";
         edtPaisId_Enabled = 0;
         edtEspectaculoName_Jsonclick = "";
         edtEspectaculoName_Enabled = 0;
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A7TipoEspectaculoId',fld:'TIPOESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E110Q1',iparms:[{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E120Q1',iparms:[{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[]");
         setEventMetadata("VALID_PAISID",",oparms:[]}");
         setEventMetadata("VALID_LUGARID","{handler:'Valid_Lugarid',iparms:[]");
         setEventMetadata("VALID_LUGARID",",oparms:[]}");
         setEventMetadata("VALID_TIPOESPECTACULOID","{handler:'Valid_Tipoespectaculoid',iparms:[]");
         setEventMetadata("VALID_TIPOESPECTACULOID",",oparms:[]}");
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
         A6PaisName = "";
         A5LugarName = "";
         A8TipoEspectaculoName = "";
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
         H000Q2_A1EspectaculoId = new short[1] ;
         H000Q2_A40000EspectaculoImagen_GXI = new string[] {""} ;
         H000Q2_A8TipoEspectaculoName = new string[] {""} ;
         H000Q2_A7TipoEspectaculoId = new short[1] ;
         H000Q2_A5LugarName = new string[] {""} ;
         H000Q2_A4LugarId = new short[1] ;
         H000Q2_A6PaisName = new string[] {""} ;
         H000Q2_A3PaisId = new short[1] ;
         H000Q2_A2EspectaculoName = new string[] {""} ;
         H000Q2_A26EspectaculoImagen = new string[] {""} ;
         hsh = "";
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA1EspectaculoId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.espectaculogeneral__default(),
            new Object[][] {
                new Object[] {
               H000Q2_A1EspectaculoId, H000Q2_A40000EspectaculoImagen_GXI, H000Q2_A8TipoEspectaculoName, H000Q2_A7TipoEspectaculoId, H000Q2_A5LugarName, H000Q2_A4LugarId, H000Q2_A6PaisName, H000Q2_A3PaisId, H000Q2_A2EspectaculoName, H000Q2_A26EspectaculoImagen
               }
            }
         );
         AV13Pgmname = "EspectaculoGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "EspectaculoGeneral";
         context.Gx_err = 0;
      }

      private short A1EspectaculoId ;
      private short wcpOA1EspectaculoId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short A4LugarId ;
      private short A7TipoEspectaculoId ;
      private short wbEnd ;
      private short wbStart ;
      private short A3PaisId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6EspectaculoId ;
      private short nGXWrapped ;
      private int edtEspectaculoId_Enabled ;
      private int edtEspectaculoName_Enabled ;
      private int edtPaisId_Enabled ;
      private int edtPaisName_Enabled ;
      private int edtLugarId_Enabled ;
      private int edtLugarName_Enabled ;
      private int edtTipoEspectaculoId_Enabled ;
      private int edtTipoEspectaculoName_Enabled ;
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
      private string edtEspectaculoId_Internalname ;
      private string edtEspectaculoId_Jsonclick ;
      private string edtEspectaculoName_Internalname ;
      private string edtEspectaculoName_Jsonclick ;
      private string edtPaisId_Internalname ;
      private string edtPaisId_Jsonclick ;
      private string edtPaisName_Internalname ;
      private string edtPaisName_Link ;
      private string edtPaisName_Jsonclick ;
      private string edtLugarId_Internalname ;
      private string edtLugarId_Jsonclick ;
      private string edtLugarName_Internalname ;
      private string edtLugarName_Link ;
      private string edtLugarName_Jsonclick ;
      private string edtTipoEspectaculoId_Internalname ;
      private string edtTipoEspectaculoId_Jsonclick ;
      private string edtTipoEspectaculoName_Internalname ;
      private string edtTipoEspectaculoName_Link ;
      private string edtTipoEspectaculoName_Jsonclick ;
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
      private string sCtrlA1EspectaculoId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A26EspectaculoImagen_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A2EspectaculoName ;
      private string A6PaisName ;
      private string A5LugarName ;
      private string A8TipoEspectaculoName ;
      private string A40000EspectaculoImagen_GXI ;
      private string A26EspectaculoImagen ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000Q2_A1EspectaculoId ;
      private string[] H000Q2_A40000EspectaculoImagen_GXI ;
      private string[] H000Q2_A8TipoEspectaculoName ;
      private short[] H000Q2_A7TipoEspectaculoId ;
      private string[] H000Q2_A5LugarName ;
      private short[] H000Q2_A4LugarId ;
      private string[] H000Q2_A6PaisName ;
      private short[] H000Q2_A3PaisId ;
      private string[] H000Q2_A2EspectaculoName ;
      private string[] H000Q2_A26EspectaculoImagen ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class espectaculogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000Q2;
          prmH000Q2 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000Q2", "SELECT T1.[EspectaculoId], T1.[EspectaculoImagen_GXI], T2.[TipoEspectaculoName], T1.[TipoEspectaculoId], T3.[LugarName], T1.[LugarId], T4.[PaisName], T3.[PaisId], T1.[EspectaculoName], T1.[EspectaculoImagen] FROM ((([Espectaculo] T1 INNER JOIN [TipoEspectaculo] T2 ON T2.[TipoEspectaculoId] = T1.[TipoEspectaculoId]) INNER JOIN [Lugar] T3 ON T3.[LugarId] = T1.[LugarId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = T3.[PaisId]) WHERE T1.[EspectaculoId] = @EspectaculoId ORDER BY T1.[EspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Q2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(2));
                return;
       }
    }

 }

}
