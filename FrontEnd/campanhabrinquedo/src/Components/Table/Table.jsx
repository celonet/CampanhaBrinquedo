import React, { Component } from 'react';
import './Table.css';

export default class Table extends Component {
    render() {
        return (
            <div>
                <table>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Nome</th>
                            <th>Age</th>
                            <th>Clothings</th>
                            <th>communities</th>
                            <th>godfathers</th>
                            <th>responsiblies</th>
                            <th>printed</th>
                            <th>gender</th>
                            <th>pcD</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.props.childs.map((child, index) => {
                                return (
                                    <tr>
                                        <td>{index + 1}</td>
                                        <td>{child.name}</td>
                                        <td>{child.age.map(a => (<div>{a.value} [{a.year}]</div>))}</td>
                                        <td>{child.clothings.map(c => (<div>{c.description} [{c.year}]</div>))}</td>
                                        <td>{child.communities.map(c => `${c.name} - ${c.neighborhood} [${c.year}]`)}</td>
                                        <td>{child.godfathers.map(g => (<div>{g.name} [{g.year}]</div>))}</td>
                                        <td>{child.responsiblies.map(r => (<div>{r.description} [{r.year}]</div>))}</td>
                                        <td>{child.printed.map(p => (<div>`${p.hasPrinted} [${p.year}]`</div>))}</td>
                                        <td>{child.gender}</td>
                                        <td>{child.pcD}</td>
                                    </tr>
                                )
                            })
                        }
                    </tbody>
                </table>
                <ul class="pagination">
                    <li class="disabled"><a href="#!"><i class="material-icons">chevron_left</i></a></li>
                    <li class="active"><a href="#!">1</a></li>
                    <li class="waves-effect"><a href="#!">2</a></li>
                    <li class="waves-effect"><a href="#!">3</a></li>
                    <li class="waves-effect"><a href="#!">4</a></li>
                    <li class="waves-effect"><a href="#!">5</a></li>
                    <li class="waves-effect"><a href="#!"><i class="material-icons">chevron_right</i></a></li>
                </ul>
            </div>
        );
    }
}