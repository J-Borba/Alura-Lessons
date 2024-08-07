import Tarefas from '@/views/Tarefas.vue';
import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router';

const routes: RouteRecordRaw[] = [
	{
		path: '/',
		name: 'Tarefas',
		component: Tarefas,
	},
];

const router = createRouter({
	history: createWebHashHistory(),
	routes: routes,
});

export default router;
