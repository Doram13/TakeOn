import Axios from 'axios';

const RESOURCE_NAME = '/Goals';

export default {
  getAll() {
    return Axios.get(RESOURCE_NAME);
  },

  get(id) {
    return Axios.get(`${RESOURCE_NAME}/${id}`);
  },

  create(data) {
    return Axios.post(RESOURCE_NAME, data);
  },

  createCommit(data) {
    return Axios.post(`${RESOURCE_NAME}/Commitment`, data);
  },

  update(id, data) {
    return Axios.put(`${RESOURCE_NAME}/${id}`, data);
  },

  delete(id) {
    return Axios.delete(`${RESOURCE_NAME}/${id}`);
  },
};
