// src/router/index.js
import Vue from 'vue';
import VueRouter from 'vue-router';
import HomeView from '@/views/HomeView.vue';
import RepositoryDetailsView from '@/views/RepositoryDetailsView.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView,
  },
  {
    path: '/repository/:id',
    name: 'repositoryDetails',
    component: RepositoryDetailsView,
  },
];

const router = new VueRouter({
  mode: 'history',
  routes,
});

export default router;
