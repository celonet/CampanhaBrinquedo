import React from 'react'
import Table from './../../Components/Table/Table';
import CampanhaApi from './../../Api/CampanhaApi';
import Typography from '@material-ui/core/Typography';

class Child extends React.Component {

    constructor() {
        super();
        this.state = {
            childs: [],
            ChildsFiltered: [],
            communities: [],
            value: ''
        }
        this.campanhaApi = new CampanhaApi();
    }

    async componentDidMount() {
        this.campanhaApi.list()
            .then(response => {
                let childs = response.data;
                let communities = childs.map(_ => _.communities[0].name);
                var distinctcommunities = [...new Set(communities)];
                this.setState({ childs: childs, ChildsFiltered: childs, communities: distinctcommunities })
            })
            .catch(console.error);
    }

    onChange(event) {
        console.log(event.target.value);
        if (event.target.value === '...') {
            this.setState({ ChildsFiltered: this.state.childs })
        } else {
            this.setState({ ChildsFiltered: this.state.childs.filter(_ => _.communities[0].name === event.target.value) })
        }
    }

    handleChange(event) {
        this.setState({ value: event.target.value, ChildsFiltered: this.state.childs.filter(v => v.name.toLowerCase().includes(event.target.value.toLowerCase())) });
    }

    render() {
        return (
            <div>
                <Typography variant="h4" gutterBottom component="h2">Child</Typography>
                <div className="filter">
                    <label>Name: </label>
                    <input value={this.state.value} onChange={this.handleChange.bind(this)} />
                    &nbsp;
                    <label>Community: </label>
                    <select
                        onChange={this.onChange.bind(this)}>
                        <option>...</option>
                        {
                            this.state.communities.map(community => {
                                return (
                                    <option key={community} value={community}>
                                        {community}
                                    </option>
                                )
                            })
                        }
                    </select>
                </div>
                <Table childs={this.state.ChildsFiltered}></Table>
            </div>
        )
    }
}

export default Child;