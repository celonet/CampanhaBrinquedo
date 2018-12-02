import mock from './mock';

export default class CampanhaApi {
    constructor() {
        this.baseUrl = 'http://localhost:5000';
    }
    list() {
        ////new mock().list()
        return fetch(`${this.baseUrl}/api/child`)
            .then(response => response.json());
    }
}