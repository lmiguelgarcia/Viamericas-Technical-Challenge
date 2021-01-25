import { agencyConstants } from '../_constants';

export function agencies(state = {}, action) {
  switch (action.type) {
    case agencyConstants.GETALLAGENCIES_REQUEST:
      return {
        loading: true
      };
    case agencyConstants.GETALLAGENCIES_SUCCESS:
      return {
        items: action.agencies
      };
    case agencyConstants.GETALLAGENCIES_FAILURE:
      return { 
        error: action.error
      };
    default:
      return state
  }
}