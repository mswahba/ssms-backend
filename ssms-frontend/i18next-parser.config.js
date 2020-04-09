module.exports = {
	createOldCatalogs: true,
	indentation: 2,
	lexers: {
		js: ['JsxLexer'],
		ts: ['JsxLexer'],
		jsx: ['JsxLexer'],
		tsx: ['JsxLexer'],
		default: ['JsxLexer'],
	},
	locales: ['ar', 'en'],
	output: 'public/translations/$LOCALE/$NAMESPACE.json',
	input: ['src/**/*.{js,jsx,ts,tsx}'],
	verbose: true,
}
