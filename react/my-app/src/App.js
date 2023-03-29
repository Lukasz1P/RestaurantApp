
import './App.css';


import {Client} from './Client';
import {Navigation} from './Navigation';

import { BrowserRouter, Route, Switch} from 'react-router-dom'


function App() {
  return (
    <BrowserRouter>
    <div className="containar">
    <h3 className="m-3 d-flex justify-content-center">
     Restauracja
     </h3>
     <Navigation/>

     <Switch>
      
        <Route path='/client' component={Client} />
      
     </Switch>
    </div>
    </ BrowserRouter>
  );
}

export default App;
