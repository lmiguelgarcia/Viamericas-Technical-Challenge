import { agencyConstants } from '../_constants';
import { agencyService } from '../_services';

export const agencyActions = {
    getAllAgencies
};

function getAllAgencies() {
    return dispatch => {
        dispatch(request());

        agencyService.getAllAgencies()
            .then(
                agencies => dispatch(success(agencies)),
                error => dispatch(failure(error))
            );
    };

    function request() { return { type: agencyConstants.GETALLAGENCIES_REQUEST } }
    function success(agencies) { return { type: agencyConstants.GETALLAGENCIES_SUCCESS, agencies } }
    function failure(error) { return { type: agencyConstants.GETALLAGENCIES_FAILURE, error } }
}