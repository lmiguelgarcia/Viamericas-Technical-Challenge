import { combineReducers } from 'redux';

import { authentication } from './authentication.reducer';
import { agencies } from './agency.reducer';
import { alert } from './alert.reducer';

const rootReducer = combineReducers({
  authentication,
  agencies,
  alert
});

export default rootReducer;