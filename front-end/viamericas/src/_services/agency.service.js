import config from 'config';
import { authHeader } from '../_helpers';
import { userService } from '../_services';

export const agencyService = {    
    getAllAgencies
};

function getAllAgencies() {
    const requestOptions = {
        method: 'GET',
        headers: authHeader()
    };
    return fetch(`${config.apiUrl}/Agency/GetAgencies`, requestOptions).then(userService.handleResponse);
}