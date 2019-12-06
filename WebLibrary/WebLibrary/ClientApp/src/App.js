import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';

import { Books } from './components/Books';
import { Orders } from './components/Orders';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
       
            <Route path='/library' component={Books} />
            <Route path='/orders' component={Orders} />


      </Layout>
    );
  }
}
