import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';   

// import { Route } from 'react-router';
import { Layout } from './components/Layout';

import { Books } from './components/Books';
import { Orders } from './components/Orders';
import { Login } from './components/login/Login';
import { Reg } from './components/login/Reg';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      // <Layout>
        <Switch>
            <Route exact path='/' component={Login} /> 
            <Route path='/regist' component={Reg} />
            
            <Route  path='/library' component={Books} />
            <Route  path='/orders' component={Orders} />
            
           
     



      {/* </Layout> */}
       
       
         </Switch>
    );
  }
}
