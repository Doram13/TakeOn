import Axios from 'axios';


// api endpoint url is given to axios, this part just extends it
const RESOURCE_NAME = '/Posts';

export default {
  getAll() {
    return Axios.get(RESOURCE_NAME);
  },

  get(id) {
    return Axios.get(`${RESOURCE_NAME}/${id}`);
  },

  update(id, data) {
    return Axios.put(`${RESOURCE_NAME}/${id}`, data);
  },

  create(data) {
    return Axios.post(RESOURCE_NAME, data);
  },

  delete(id) {
    return Axios.delete(`${RESOURCE_NAME}/${id}`);
  },
};
