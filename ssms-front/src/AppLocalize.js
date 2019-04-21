import { LMSLayout } from './LMSLayout';
import React, { Component } from 'react'
import { renderToStaticMarkup } from 'react-dom/server'
import { BrowserRouter } from 'react-router-dom'
import { Switch, Route } from 'react-router-dom'
import { withLocalize, getActiveLanguage } from 'react-localize-redux'
import LMSLayout from './lms-ui/LMSLayout'
import MediaLayout from './media-ui/MediaLayout'
import { store } from './AppStore'

class AppLocalize extends Component {
  constructor(props) {
    super(props);
    // import all translation files dynamically from './translations' dir
    // and concat them into one global translation object [globalTrans]
    const importAll = (r) => r.keys().map(r);
    const globalTrans = importAll(require.context('./translations', false, /\.json$/))
                          .reduce( (acc, _module) => {
                            acc = {...acc, ..._module};
                            return acc;
                          },{});
    // initialize localize
    props.initialize({
      languages: [
        { name: "English", code: "en" },
        { name: "Arabic",  code: "ar" }
      ],
      translation: globalTrans, //{...schoolsTrans, ...usersTrans},
      options: { renderInnerHtml: true, renderToStaticMarkup }
    });
    // set active language manually
    props.setActiveLanguage('ar');
  }
  render() {
    const lang = getActiveLanguage(store.getState().localize).code;
    const styleLinks = (lang === 'en')
      ? <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-rc.2/css/materialize.min.css' />
      : [
          <link key={1} rel="stylesheet" href='https://gitcdn.xyz/cdn/MahdiMajidzadeh/materialize-rtl/b305c8ad018eb8198854e6dc4c43eab592e89eb1/dist/css/materialize-rtl.min.css' />,
          <link key={2} rel="stylesheet" href='/rtl-styles.css' />
        ]
    return (
      <>
        {styleLinks}
        <BrowserRouter>
          <Switch>
            {/* Learning Management System Site */}
            <Route path="/lms" component={LMSLayout} />
            {/* Media Site */}
            <Route path="/" component={MediaLayout} />
          </Switch>
        </BrowserRouter>
      </>
    );
  }
}

export default withLocalize(AppLocalize);