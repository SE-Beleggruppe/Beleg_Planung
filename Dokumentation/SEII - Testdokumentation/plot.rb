#!/usr/bin/ruby
# -*- coding: utf-8 -*-

d = Dir.open "."

basename = "table"

plot = File.open "plot", "w"

plot.puts "reset"
plot.puts "unset xtics"

lines  = []
lw     = []
size   = nil

File.read("settings.conf").scan(/\s*(\S+)\s*{([^}]+)/).each do
  |group, inner|
  case group
  when /^diagramm$/i
    inner.scan(/(\S*)\s*=\s*([^#]*?)\s*[#\n]/).each do
      |k,v|

      puts k + " = '" + v + "'"
      next if /^auto$/i.match v

      case k
      when /^x$/i
        plot.puts "set xrange [" + v + "]"
      when /^xabst$/i
        plot.puts "set xtics " + v
      when /^y$/i
        plot.puts "set yrange [" + v + "]"
      when /^yabst$/i
        plot.puts "set ytics " + v
      when /^größe$/i
        size = "size " + v
      when /^breiteMarke$/i
        lw[0] = v
      when /^breiteDaten$/i
        lw[1] = v
      end
    end
  when /^daten$/i
    inner.scan(/(\S*)\s*=\s*([^#]*?)\s*[#\n]/).each do
      |k, v|
      k = k.match(/^marke$/i) ? nil : ("'" + k + "'")
      tmp = v.split(":")
      line = 
        k.to_s + (k ? "using ($0+1):" + tmp[0] + " with lines": tmp[0]) + 
        (tmp[1].match(/^auto$/i) ? "" : " lc " + tmp[1].sub("'", "rgb '#")) +
        " lw " + (k ? lw[1] : lw[0]) +
        " title '" + tmp[2].to_s + "'"
      lines.push line
    end
  end
end

plot.puts "set terminal pngcairo enhanced font 'arial' " + size.to_s
plot.puts "set output '" + basename + ".png'"
plot.print "plot " + (lines * ", ")
first = true

plot.close

`gnuplot plot`

File.delete "plot"

d.close
