<script lang="ts">
	import {
		Header,
		HeaderNav,
		HeaderNavItem,
		HeaderNavMenu,
		SkipToContent,
		Content,
		Grid,
		Row,
		Column,
		Form,
		TextInput,
		DatePicker,
		DatePickerInput,
		Button,
		DataTable
	} from 'carbon-components-svelte';
	import type { PageData } from './$types';
	import type { DataTableRow } from 'carbon-components-svelte/types/DataTable/DataTable.svelte';
	import { enhance } from '$app/forms';

	let todo_name: string;
	let date_input: string;

	export let data: PageData;
	$: rows = parseRows(data);

	function parseRows(data: PageData): DataTableRow[] {
		var rows = Array<DataTableRow>();
		data.items.forEach((item) => {
			rows.push({ id: item.guid, title: item.title, dueDate: item.dueDate });
		});
		return rows;
	}
</script>

<Content>
	<DataTable
		headers={[
			{ key: 'title', value: 'Title' },
			{ key: 'dueDate', value: 'Due Date' }
		]}
		{rows}
	/>
	<br />
	<form id="new-todo" action="/" method="POST" use:enhance>
		<TextInput
			bind:value={todo_name}
			name="name"
			labelText="ToDo Name"
			placeholder="follow your dreams"
		/>
		<DatePicker bind:value={date_input} datePickerType="single" dateFormat="d/m/Y" on:change>
			<DatePickerInput labelText="Due Date" name="dueDate" placeholder="dd/mm/yyyy" />
		</DatePicker>
		<Button type="submit">New ToDo</Button>
	</form>

	<!--
	<Grid>
		<Row>
			<Column>
				<h1>Welcome</h1>
			</Column>
		</Row>
	</Grid>
-->
</Content>
