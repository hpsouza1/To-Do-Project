import Vue from 'vue';
import Router from 'vue-router';
import Home from '../views/Home.vue';
import TodoDetails from '../views/TodoDetails.vue';
import CreateTask from '../views/CreateTask.vue';

Vue.use(Router);

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/todo/:id', name: 'TodoDetails', component: TodoDetails },
  { path: '/create-task', name: 'CreateTask', component: CreateTask }
];

const router = new Router({
  mode: 'history',
  routes
});

export default router;
