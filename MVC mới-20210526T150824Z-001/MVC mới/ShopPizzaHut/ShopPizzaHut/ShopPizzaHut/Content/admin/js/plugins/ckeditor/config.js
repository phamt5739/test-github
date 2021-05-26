/**
 * @license Copyright (c) 2003-2020, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';

	config.syntaxhighlight_lang = 'csharp';
	config.syntaxhighlight_hideControls = true;
	config.language = 'vi';
	config.filebrowserBrowseUrl = '/Content/admin/js/plugins/ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '/Content/admin/js/plugins/ckfinder/ckfinder.html?Type=Images';
	config.filebrowserFlashBrowseUrl = '/Content/admin/js/plugins/ckfinder/ckfinder.html?Type=Flash';
	config.filebrowserUploadUrl = '/Content/admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '/Data';
	config.filebrowserFlashUploadUrl = '/Content/admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

	CKFinder.setupCKEditor(null,'/Content/admin/js/plugins/ckfinder')
};
