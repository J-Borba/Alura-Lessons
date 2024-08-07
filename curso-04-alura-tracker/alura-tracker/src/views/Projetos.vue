<template>
	<section class="projetos">
		<h1 class="title">Projetos</h1>
		<form @submit.prevent="salvar">
			<div class="field">
				<label for="nomeProjeto" class="label"> Nome do Projeto </label>
				<input type="text" class="input" v-model="nomeProjeto" id="nomeProjeto" />
			</div>
			<div class="field">
				<button class="button" type="submit">Salvar</button>
			</div>
		</form>
		<table class="table is-fullwidth">
			<thead>
				<tr>
					<th>Id</th>
					<th>Nome</th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="(projeto, index) in projetos" :key="index">
					<td>{{ projeto.id }}</td>
					<td>{{ projeto.nome }}</td>
				</tr>
			</tbody>
		</table>
	</section>
</template>

<script lang="ts">
	import IProjeto from '@/interfaces/IProjeto';
	import { defineComponent } from 'vue';

	export default defineComponent({
		name: 'Projetos',
		data() {
			return {
				nomeProjeto: '',
				projetos: [] as IProjeto[],
			};
		},
		methods: {
			salvar() {
				const projeto: IProjeto = {
					nome: this.nomeProjeto,
					id: new Date().toISOString(),
				};

				this.projetos.push(projeto);
				this.nomeProjeto = '';
			},
		},
	});
</script>

<style scoped>
	.projetos {
		padding: 1.25rem;
	}
</style>
