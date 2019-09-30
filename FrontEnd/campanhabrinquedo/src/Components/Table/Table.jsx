import React, { Component } from 'react';
import './Table.css';
import CampanhaApi from './../../Api/CampanhaApi';

export default class Table extends Component {

    constructor(props) {
        super(props);
        this.gridOptions = {
            columnDefs: [
                { headerName: "#", field: "num", checkboxSelection: true },
                { headerName: "Nome", field: "name" },
                { headerName: "Age", field: "age" },
                { headerName: "Community", field: "community" },
                { headerName: "Pcd", field: "pcd" }
            ],
            rowData: null,
            animateRows: false,
            groupUseEntireRow: true,
            onRowGroupOpened: (event) => {
                var rowNodeIndex = event.node.rowIndex;
                var childCount = event.node.childrenAfterSort ? event.node.childrenAfterSort.length : 0;
                var newIndex = rowNodeIndex + childCount;
                this.gridOptions.api.ensureIndexVisible(newIndex);
            }
        };
        this.campanhaApi = new CampanhaApi();
    }

    parseData(data) {
        return data.map((child, index) => {
            return {
                id: child.id,
                num: index + 1,
                name: child.name,
                age: this.getAge(child),
                community: this.getCommunity(child),
                pcd: child.pcd
            };
        });
    }

    getAge(child) {
        var age = (child.age || []).length > 0 ? child.age[0] : { value: '', year: '' };
        return age.value;
    }
    
    getCommunity(child) {
        var community = child.communities ? child.communities[0] : { name: '', neighborhood: '', year: '' };
        return `${community.name} - ${community.neighborhood}`;
    }
    getClothing(child) {
        var clothing = child.clothings ? child.clothings[0] : { description: '', year: '' };
        return clothing.description;
    }

    onButtonClick = e => {
        const selectedNodes = this.gridApi.getSelectedNodes()
        const selectedData = selectedNodes.map(node => node.data)
        if (selectedData.length > 1) {
            const selectedDataStringPresentation = selectedData.map(node => node.num + ' ' + node.name).join(', ')
            alert(`Tem certeza que deseja juntar? ${selectedDataStringPresentation}`);
            const data1 = selectedData[0];
            const data2 = selectedData[1];
            this.campanhaApi.associate(data1.id, data2.id)
                .then(data => {
                    console.log(data.json());
                })
                .catch(err => console.error(err.message));
        } else {
            alert('Deve ser selecionado ao menos 2 registros');
        }
    }

    render() {
        return (
            <div className="ag-theme-balham" style={{ height: '600px' }}>
                {/* <button onClick={this.onButtonClick}>Juntar</button> */}
                <table>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Nome</th>
                            <th>Age</th>
                            <th>Clothing</th>
                            <th>Community</th>
                            <th>pcD</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            (this.props.childs || []).map((child, index) => {
                                return (
                                    <tr key={child.id}>
                                        <td>{index + 1}</td>
                                        <td>{child.name}</td>
                                        <td>{this.getAge(child)}</td>
                                        <td>{this.getClothing(child)}</td>
                                        <td>{this.getCommunity(child)}</td>
                                        <td>{child.pcD}</td>
                                    </tr>
                                )
                            })
                        }
                    </tbody>
                </table>

            </div>
        );
    }
}