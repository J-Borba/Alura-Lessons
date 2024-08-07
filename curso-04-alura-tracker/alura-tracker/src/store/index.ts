import IProjeto from '@/interfaces/IProjeto';
import { InjectionKey } from 'vue';
import { createStore, Store } from 'vuex';

interface Estado {
	projetos: IProjeto[];
}

export const key: InjectionKey<Store<Estado>> = Symbol();

export const store = createStore<Estado>({
	state: {
		projetos: [],
	},
	mutations: {
		adicionarProjeto(state, novoProjeto: IProjeto) {
			state.projetos.push(novoProjeto);
		},
	},
	actions: {},
	modules: {},
});
