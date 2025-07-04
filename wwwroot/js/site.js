// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(async function () {
    const res = await fetch("/api/book/want-to-read");
    const json = await res.json();
    const books = json.reading_log_entries.map(e => ({
        title: e.work.title,
        author: e.work.author_names?.[0] ?? 'Unknown',
        year: e.work.first_publish_year ?? 'Unknown'
    }));

    // === Tabel ===
    const tbody = $("#bookTable tbody");
    books.forEach(b => {
        tbody.append(`<tr><td>${b.title}</td><td>${b.author}</td><td>${b.year}</td></tr>`);
    });

    $("#bookTable").DataTable({
        responsive: true
    });

    // === Data Aggregation ===
    const yearData = Array.from(d3.rollup(books, v => v.length, d => d.year), ([year, count]) => ({ year, count }));
    const authorData = Array.from(d3.rollup(books, v => v.length, d => d.author), ([author, count]) => ({ author, count }))
        .sort((a, b) => b.count - a.count).slice(0, 5);

    function renderCharts() {
        // Clear SVGs
        d3.selectAll("#barChart > *, #lineChart > *, #pieChart > *").remove();

        const barSvg = d3.select("#barChart");
        const lineSvg = d3.select("#lineChart");
        const pieSvg = d3.select("#pieChart");

        // Get container widths
        const bw = barSvg.node().getBoundingClientRect().width;
        const lw = lineSvg.node().getBoundingClientRect().width;
        const pw = pieSvg.node().getBoundingClientRect().width;
        const height = 300;
        const margin = { top: 20, right: 20, bottom: 50, left: 50 };

        // === BAR CHART ===
        barSvg.attr("viewBox", `0 0 ${bw} ${height}`).attr("preserveAspectRatio", "xMidYMid meet");
        const bx = d3.scaleBand().domain(yearData.map(d => d.year)).range([margin.left, bw - margin.right]).padding(0.1);
        const by = d3.scaleLinear().domain([0, d3.max(yearData, d => d.count)]).range([height - margin.bottom, margin.top]);
        barSvg.selectAll("rect")
            .data(yearData).enter().append("rect")
            .attr("x", d => bx(d.year)).attr("y", d => by(d.count))
            .attr("height", d => height - margin.bottom - by(d.count)).attr("width", bx.bandwidth())
            .attr("fill", "steelblue");
        barSvg.append("g").attr("transform", `translate(0,${height - margin.bottom})`)
            .call(d3.axisBottom(bx)).selectAll("text").attr("transform", "rotate(-45)").style("text-anchor", "end");
        barSvg.append("g").attr("transform", `translate(${margin.left},0)`).call(d3.axisLeft(by));

        // === LINE CHART ===
        lineSvg.attr("viewBox", `0 0 ${lw} ${height}`).attr("preserveAspectRatio", "xMidYMid meet");
        const lx = d3.scalePoint().domain(yearData.map(d => d.year)).range([margin.left, lw - margin.right]);
        const ly = d3.scaleLinear().domain([0, d3.max(yearData, d => d.count)]).range([height - margin.bottom, margin.top]);
        const line = d3.line().x(d => lx(d.year)).y(d => ly(d.count));
        lineSvg.append("path").datum(yearData).attr("d", line).attr("stroke", "tomato").attr("fill", "none").attr("stroke-width", 2);
        lineSvg.append("g").attr("transform", `translate(0,${height - margin.bottom})`).call(d3.axisBottom(lx));
        lineSvg.append("g").attr("transform", `translate(${margin.left},0)`).call(d3.axisLeft(ly));

        // === PIE CHART ===
        const radius = Math.min(pw, height) / 2 - 10;
        pieSvg.attr("viewBox", `0 0 ${pw} ${height}`).attr("preserveAspectRatio", "xMidYMid meet");
        const pieGroup = pieSvg.append("g").attr("transform", `translate(${pw / 2},${height / 2})`);
        const pie = d3.pie().value(d => d.count);
        const arc = d3.arc().innerRadius(0).outerRadius(radius);
        pieGroup.selectAll("path")
            .data(pie(authorData)).enter().append("path")
            .attr("d", arc).attr("fill", (d, i) => d3.schemeCategory10[i]);
        pieGroup.selectAll("text")
            .data(pie(authorData)).enter().append("text")
            .attr("transform", d => `translate(${arc.centroid(d)})`)
            .text(d => d.data.author).style("font-size", "10px").attr("text-anchor", "middle");
    }

    renderCharts();
    window.addEventListener("resize", renderCharts);
});

