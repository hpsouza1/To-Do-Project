import Vue from 'vue';
import Router from 'vue-router';
import Home from '../views/Home.vue';
import TodoDetails from '../views/TodoDetails.vue';
import CreateTask from '../views/CreateTask.vue';
import EditTask from '@/views/EditTask.vue';
import CompletedTasks from '@/views/CompletedTasks.vue';

Vue.use(Router);

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/todo/:id', name: 'TodoDetails', component: TodoDetails },
  { path: '/create-task', name: 'CreateTask', component: CreateTask },
  { path: '/edit-task/:id', name: 'EditTask', component: EditTask},
  { path: '/completed-tasks', name: 'CompletedTasks', component: CompletedTasks },
];

const router = new Router({
  mode: 'history',
  routes
});

export default router;